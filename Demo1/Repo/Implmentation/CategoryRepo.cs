using Demo1.Data;
using Demo1.Models;
using Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Repo.Implmentation
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Category> GetCategoriesWithVehicleCount()
        {
           return _context.Categories.Include(x=>x.Vehicles).ToList();
        }
    }
}
