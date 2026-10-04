using AutoMapper;
using Demo1.DTOs;
using Demo1.Models;
using Demo1.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public VehicleController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll() { 
        
            var s=_unit.Vehicles.GetAll();
            var dto=_mapper.Map<List<GetVheicleDTO>>(s);

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(CreateVheicleDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var v =_mapper.Map<Vehicle>(dto);
            _unit.Vehicles.Add(v);
            _unit.Save();
            return Created();
        }

        [HttpPut]
        public IActionResult Update(int id,CreateVheicleDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var s =_unit.Vehicles.GetById(id);
            if (s == null) {
                return NotFound();
            }
            _mapper.Map(dto, s);
            _unit.Vehicles.Update(s);
            _unit.Save();
            return Created();
        }


        [HttpDelete]
        public IActionResult Delete(int id) {
            var s = _unit.Vehicles.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            _unit.Vehicles.Delete(id);
            _unit.Save();
            return NoContent();

        }

        [HttpGet("Avilable-Vehicle")]
        public IActionResult GetAvailableVehicle()
        {
            var s = _unit.Vehicles.GetAvilableVehicle();
            var dto = _mapper.Map<List<GetVheicleDTO>>(s);
            return Ok(dto);
        }
    }
}
