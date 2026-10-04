using Demo1.Models;

namespace Demo1.Repo.Interfaces
{
    public interface ICategoryRepo:IGenericRepo<Category>
    {
       List<Category> GetCategoriesWithVehicleCount();
    }
}
