using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.DAL.Entities
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
