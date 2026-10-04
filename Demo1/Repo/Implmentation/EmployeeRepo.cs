using Demo1.Data;
using Demo1.Models;
using Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Repo.Implmentation
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {
        private readonly AppDbContext _context;
        public EmployeeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Employee> GetEmployeesWithSalesCount()
        {
            return _context.Employees.Include(x=>x.Sales).ToList();
        }

        public Employee GetEmployeeWithSaleById(int id)
        {
            var m = _context.Employees.Include(x => x.Sales).FirstOrDefault(x=>x.Id==id);
            return m;
        }
    }
}
