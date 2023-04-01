namespace WebApplication6.Models
{
    public class ProductVM
    {
        public int id { get; set; }
        public string? ProductName { get; set; }
        public int? Price { get; set; }
        public string? PhotoName { get; set; }
        public IFormFile? PhotoUrl { get; set; }

    }
}
