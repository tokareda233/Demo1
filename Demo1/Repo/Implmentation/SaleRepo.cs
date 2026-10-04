using Demo1.Data;
using Demo1.Models;
using Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Repo.Implmentation
{
    public class SaleRepo : GenericRepo<Sale>, ISaleRepo
    {
        private readonly AppDbContext _Context;
        public SaleRepo(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        public List<Sale> GetSalesWithRelatedDetails()
        {
            return _Context.Sales.Include(x => x.Vehicle)
                .Include(x => x.Customer)
                .Include(x => x.Employee).ToList();
                
        }
    }
}
