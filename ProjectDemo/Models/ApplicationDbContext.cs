using Microsoft.EntityFrameworkCore;
using ProjectDemo.DAL;

namespace ProjectDemo.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Product_Category> categories { get; set; }
      
    }
}
