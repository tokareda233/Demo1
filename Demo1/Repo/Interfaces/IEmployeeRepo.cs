using Demo1.Models;

namespace Demo1.Repo.Interfaces
{
    public interface IEmployeeRepo:IGenericRepo<Employee>
    {
        List<Employee> GetEmployeesWithSalesCount();
        Employee GetEmployeeWithSaleById(int id);
    }
}
