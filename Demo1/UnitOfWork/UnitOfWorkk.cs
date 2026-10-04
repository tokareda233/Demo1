using Demo1.Data;
using Demo1.Models;
using Demo1.Repo.Interfaces;

namespace Demo1.UnitOfWork
{
    public class UnitOfWorkk : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IVehicle Vehicles {  get;  }
        public ICategoryRepo Category { get; }
        public IEmployeeRepo Employee { get; }
        public ISaleRepo Sales { get; }
        public ICustomerrRepo Customer { get; }
        public IGenericRepo<CustomerProfile> Customerprofile { get; }
        public UnitOfWorkk(AppDbContext context, IVehicle vehicles, ICategoryRepo categoryRepo, IEmployeeRepo employee, ISaleRepo sales, ICustomerrRepo customer, IGenericRepo<CustomerProfile> customerprofile)
        {
            _context = context;
            Vehicles = vehicles;
            Category = categoryRepo;
            Employee = employee;
            Sales = sales;
            Customer = customer;
            Customerprofile = customerprofile;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
