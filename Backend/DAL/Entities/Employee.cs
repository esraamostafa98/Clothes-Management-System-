using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.DAL.Entities
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }

        public string PhotoName { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")] 
        public Department Department { get; set; }
    }
}
