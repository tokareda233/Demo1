using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal SalePrice { get; set; }
        [Required]
        [MaxLength(30)]
        public string PaymentMethod { get; set; }
        [Required]
        [MaxLength(300)]
        public string Notes {  get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer ?Customer { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        public Employee ?Employee { get; set; }

        [ForeignKey("Vehicleid")]
        public int Vehicleid { get; set; }
        public Vehicle ?Vehicle { get; set; }

    }
}
