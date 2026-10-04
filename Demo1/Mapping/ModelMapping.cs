using AutoMapper;
using Demo1.DTOs;
using Demo1.Models;

namespace Demo1.Mapping
{
    public class ModelMapping:Profile
    {
        public ModelMapping()
        {
            CreateMap<Vehicle,GetVheicleDTO>();
            CreateMap<CreateVheicleDTO, Vehicle>();


            CreateMap<Category, GetCategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>();

            CreateMap<Employee, GetEmployeeDTO>();
            CreateMap<CreateEmployeeDTO, Employee>();


            CreateMap<CreateSaleDTO, Sale>();
        }
    }
}
