using System.Net;
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
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public CustomerController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var s = _unit.Customer.GetAllWithProfile();

            var n = s.Select(x => new
            {
                Id=x.Id,
                FullName=x.FullName,
                Email=x.Email,
                Phone=x.Phone,
                DriverLicenseNumber=x.DriverLicenseNumber,
                CustomerprofileId=x.CustomerProfile.Id,
                Address=x.CustomerProfile.Address,
                City=x.CustomerProfile.City,
                Nationality=x.CustomerProfile.Nationality,
                DateOfBirth=x.CustomerProfile.DateOfBirth,
                TotalPrice=x.sales.Sum(z=>z.SalePrice)

            });
            return Ok(n);
        }

        [HttpPost]
        public IActionResult Add(CreateCustomerDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var customer = new Customer
            {
                FullName=dto.FullName,
                Email=dto.Email,
                Phone=dto.Phone,
                DriverLicenseNumber=dto.DriverLicenseNumber,

            };

            var profile = new CustomerProfile
            {
                Address=dto.Address,
                City=dto.City,
                Nationality=dto.Nationality,
                DateOfBirth=dto.DateOfBirth,
                CustomerId=customer.Id,
            };
            _unit.Customer.Add(customer);
            _unit.Customerprofile.Add(profile);
            _unit.Save();
            return Created();
        }

        [HttpPut]
        public IActionResult Update(int id, CreateCustomerDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var s = _unit.Customer.GetByIDWithSales(id);
            if (s == null)
            {
                return NotFound();
            }
            var c = _unit.Customerprofile.GetById(s.CustomerProfile.Id);
            if (c== null)
            {
                return NotFound();
            }
            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                DriverLicenseNumber = dto.DriverLicenseNumber,

            };

            var profile = new CustomerProfile
            {
                Address = dto.Address,
                City = dto.City,
                Nationality = dto.Nationality,
                DateOfBirth = dto.DateOfBirth,
                CustomerId = customer.Id,
            };
            _mapper.Map(customer, s);
            _mapper.Map(profile, c);

            _unit.Customer.Update(s);
            _unit.Customerprofile.Update(c);
            _unit.Save();
            return NoContent();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var s = _unit.Customer.GetById(id);
            if (s == null)
            {
                return NotFound();
            }
            _unit.Customer.Delete(id);
            _unit.Save();
            return NoContent();

        }

    }
}
