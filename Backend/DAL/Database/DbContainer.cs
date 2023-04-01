using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DAL.Entities;
using File = WebApplication6.DAL.Entities.File2;

namespace WebApplication6.DAL.Database
{
    public class DbContainer:IdentityDbContext
    {
        public DbContainer(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Product { get; set; }
        
        public DbSet<File2> File2 { get; set; }
        public DbSet<Files> Files { get; set; }
    }
}
