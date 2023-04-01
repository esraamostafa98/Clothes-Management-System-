using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.DAL.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string PhotoName { get; set; }
       
    }
}
