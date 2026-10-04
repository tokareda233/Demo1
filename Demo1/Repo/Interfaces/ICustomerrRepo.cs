using Demo1.Models;

namespace Demo1.Repo.Interfaces
{
    public interface ICustomerrRepo:IGenericRepo<Customer>
    {
        Customer GetByIDWithSales(int id);
        List<Customer> GetAllWithProfile();
    }
}
