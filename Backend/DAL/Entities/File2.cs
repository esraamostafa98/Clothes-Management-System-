using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.DAL.Entities
{
    [Table("File2")]
    public class File2
    {
            public string Id { get; set; }
            public string PhotoName { get; set; }
        
    }
}
