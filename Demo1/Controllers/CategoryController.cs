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
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var s = _unit.Category.GetAll();
            var dto = _mapper.Map<List<GetCategoryDTO>>(s);

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(CreateCategoryDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var v = _mapper.Map<Category>(dto);
            _unit.Category.Add(v);
            _unit.Save();
            return Created();
        }

        [HttpPut]
        public IActionResult Update(int id, CreateCategoryDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var s = _unit.Category.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, s);
            _unit.Category.Update(s);
            _unit.Save();
            return Created();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var s = _unit.Category.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            _unit.Category.Delete(id);
            _unit.Save();
            return NoContent();

        }

        [HttpGet("Details")]
        public IActionResult GetWithVehicleCount()
        {
            var v =_unit.Category.GetCategoriesWithVehicleCount();

            var c = v.Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Description=x.Description,
                VehicleCount=x.Vehicles.Count()

            });

            return Ok(c);
        }

    }
}
