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
    public class EmployeeController : ControllerBase
    {

        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var s = _unit.Employee.GetEmployeesWithSalesCount();
            // var dto = _mapper.Map<List<GetEmployeeDTO>>(s);

            var dto = s.Select(x => new
            {
                FullName=x.FullName,
                Position=x.Position,
                Email=x.Email,
                Phone=x.Phone,
                HireDate=x.HireDate,
                SalesCount=x.Sales.Count()

            }).OrderByDescending(x=>x.SalesCount).ToList();

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(CreateEmployeeDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var v = _mapper.Map<Employee>(dto);
            _unit.Employee.Add(v);
            _unit.Save();
            return Created();
        }

        [HttpPut]
        public IActionResult Update(int id, CreateEmployeeDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var s = _unit.Employee.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, s);
            _unit.Employee.Update(s);
            _unit.Save();
            return Created();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var s = _unit.Employee.GetEmployeeWithSaleById(id);
            if (s == null)
            {
                return NotFound();
            }
            if (s.Sales.Count() < 0)
            {
                return BadRequest("There are associated sales");
            }
            _unit.Employee.Delete(id);
            _unit.Save();
            return NoContent();

        }
    }
}
