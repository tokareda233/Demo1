using Demo1.Data;
using Demo1.Models;
using Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Repo.Implmentation
{
    public class CustomerRepo : GenericRepo<Customer>, ICustomerrRepo
    {
        private readonly AppDbContext _context;
        public CustomerRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Customer> GetAllWithProfile()
        {
           return _context.Customers.Include(c=>c.CustomerProfile).Include(c=>c.sales).Include(x=>x.CustomerProfile).ToList();
        }

        public Customer GetByIDWithSales(int id)
        {
           return _context.Customers.Include(c=>c.sales).FirstOrDefault(c=>c.Id==id);
        }
    }
}
