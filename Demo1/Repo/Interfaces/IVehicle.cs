using Demo1.Models;

namespace Demo1.Repo.Interfaces
{
    public interface IVehicle:IGenericRepo<Vehicle>
    {
       List<Vehicle> GetAvilableVehicle();
    }
}
