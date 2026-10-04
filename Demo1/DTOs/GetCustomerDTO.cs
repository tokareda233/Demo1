using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.DTOs
{
    public class GetCustomerDTO
    {
        public int Id { get; set; }
        
        public string FullName { get; set; }
       
        public string Email { get; set; }
        
        public string Phone { get; set; }
       
        public string DriverLicenseNumber { get; set; }

        public int customerprofileId { get; set; }
       
        public string Address { get; set; }

        
        public string? City { get; set; }
       
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public decimal TotalPrice { get; set; }

        
        

        
    }
}
