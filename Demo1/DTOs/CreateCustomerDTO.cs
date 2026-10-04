using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.DTOs
{
    public class CreateCustomerDTO
    {
        public string FullName { get; set; }
       
        public string Email { get; set; }
       
        public string Phone { get; set; }
        
        public string DriverLicenseNumber { get; set; }
        public string Address { get; set; }

      
        public string? City { get; set; }
        
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
       
    }
}
