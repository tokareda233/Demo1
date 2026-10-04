using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo1.DTOs
{
    public class GetVheicleDTO
    {
        public int Id { get; set; }
        
        public string Make { get; set; }
       
        public string Model { get; set; }
       
        public int Year { get; set; }
       
        public string? color { get; set; }
       
        public decimal Price { get; set; }
      
        public int Mileage { get; set; }
        
        public string VIN { get; set; }
        
        public string? FuelType { get; set; }
      
        public string? Transmission { get; set; }
       
        public string Status { get; set; }
      
        public int CategoryId { get; set; }
    }
}
