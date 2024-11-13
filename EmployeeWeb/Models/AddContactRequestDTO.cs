namespace EmployeeWeb.Models
{
    public class AddContactRequestDTO
    {
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public string JobTitle { get; set; }  
        public string Salary { get; set; }  
        public string Department { get; set; }
    }

    public class UpdateContactRequestDTO : AddContactRequestDTO
    {
        public Guid Id { get; set; }
    }
}
