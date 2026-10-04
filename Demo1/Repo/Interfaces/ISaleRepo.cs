using Demo1.Models;

namespace Demo1.Repo.Interfaces
{
    public interface ISaleRepo:IGenericRepo<Sale>
    {
        List<Sale> GetSalesWithRelatedDetails();

     }
}
