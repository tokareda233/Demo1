using Demo1.Models;
using Demo1.Repo.Interfaces;

namespace Demo1.UnitOfWork
{
    public interface IUnitOfWork
    {
        IVehicle Vehicles { get; }
        ICategoryRepo Category { get; }
        IEmployeeRepo Employee { get; }
        ISaleRepo Sales { get; }
        ICustomerrRepo Customer { get; }
        IGenericRepo<CustomerProfile> Customerprofile { get; }
        public void Save();
    }
}
