using Demo1.Data;
using Demo1.Models;
using Demo1.Repo.Interfaces;

namespace Demo1.Repo.Implmentation
{
    public class VehicleRepo : GenericRepo<Vehicle>, IVehicle
    {
        private readonly AppDbContext _context;
        public VehicleRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Vehicle> GetAvilableVehicle()
        {
            return _context.Vehicles.Where(c => c.Status == "Available")
                .OrderByDescending(c => c.Year)
                .ThenBy(x => x.Price).ToList();
        }
    }
}
