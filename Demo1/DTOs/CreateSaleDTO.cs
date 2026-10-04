using Demo1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo1.DTOs
{
    public class CreateSaleDTO
    {
        public DateTime SaleDate { get; set; }
       
        public decimal SalePrice { get; set; }
       
        public string PaymentMethod { get; set; }
       
        public string Notes { get; set; }

       
        public int CustomerId { get; set; }
       
        public int EmployeeId { get; set; }

        public int Vehicleid { get; set; }
    }
}
