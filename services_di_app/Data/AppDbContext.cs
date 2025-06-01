using Microsoft.EntityFrameworkCore;
using services_di_app.Models;

namespace services_di_app.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //...........
        }
    }
}
