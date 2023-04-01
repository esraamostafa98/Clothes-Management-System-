using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.DAL.Entities
{
    [Table("Files")]
    public class Files
    {
        public int id { get; set; }
        public string PhotoName { get; set; }
    }
}
