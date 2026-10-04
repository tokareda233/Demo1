using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Make { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [MaxLength(50)]
        public string? color { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public  int Mileage { get; set; }
        [Required]
        [MaxLength(17)]
        public string VIN { get; set; }
        [MaxLength(30)]
        public string ?FuelType { get; set; }
        [MaxLength(30)]
        public string  ?Transmission {  get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

         public  Category ?Category { get; set; }

        public Sale ?Sale { get; set; }

    }
}
