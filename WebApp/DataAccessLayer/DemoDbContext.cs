using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DemoDbContext:DbContext
    {
        public DemoDbContext()
        {
            
        }
        public DemoDbContext(DbContextOptions options):base(options) {
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=localhost;Initial Catalog=questponddb;Integrated Security=True;TrustServerCertificate=True";
                optionsBuilder.UseSqlServer(connectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

       

    }
}
