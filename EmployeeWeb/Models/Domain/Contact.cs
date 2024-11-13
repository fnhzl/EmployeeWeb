using System.ComponentModel.DataAnnotations;

namespace EmployeeWeb.Models.Domain
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public string JobTitle { get; set; }  
        public string Salary { get; set; }   
        public string Department { get; set; } 
    }
}
