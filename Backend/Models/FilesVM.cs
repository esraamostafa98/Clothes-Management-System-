namespace WebApplication6.Models
{
    public class FilesVM
    {
        public int Id { get; set; }
        public string? PhotoName { get; set; }
        public IFormFile PhotoUrl { get; set; }
    }
}
