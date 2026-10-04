using System.ComponentModel.DataAnnotations;

namespace Demo1.DTOs
{
    public class CreateEmployeeDTO
    {
        public string FullName { get; set; }
       
        public string Position { get; set; }
       
        public string Email { get; set; }
       
        public string Phone { get; set; }
       
        public DateTime HireDate { get; set; }
    }
}
