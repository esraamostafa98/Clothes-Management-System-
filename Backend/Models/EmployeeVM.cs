namespace WebApplication6.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }
        public string? PhotoName { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
