using AutoMapper;
using Demo1.DTOs;
using Demo1.Models;
using Demo1.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SaleController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var s = _unit.Sales.GetSalesWithRelatedDetails();

            var n = s.GroupBy(x=>x.EmployeeId).Select(x => new
            {
                EmployeeId = x.Key,
                
            }).ToList();
            return Ok(n);
        }

        [HttpPost]
        public IActionResult Add(CreateSaleDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var v = _mapper.Map<Sale>(dto);
           var vehicle=_unit.Vehicles.GetById(dto.Vehicleid);
            if (vehicle == null)
            {
                return BadRequest("the Vehicle not found");
            }

            if(vehicle.Status!= "Available")
            {
                return BadRequest("Vehicle not Available");
            }
           
            vehicle.Status = "Sold";
            _unit.Sales.Add(v);
            _unit.Vehicles.Update(vehicle);
            _unit.Save();
            return Created();
        }

        [HttpPut]
        public IActionResult Update(int id, CreateSaleDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var s = _unit.Sales.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, s);
            _unit.Sales.Update(s);
            _unit.Save();
            return Created();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var s = _unit.Sales.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            _unit.Sales.Delete(id);
            _unit.Save();
            return NoContent();

        }
    }
}
