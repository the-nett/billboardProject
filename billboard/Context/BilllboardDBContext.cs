using billboard.Model;
using Microsoft.EntityFrameworkCore;

namespace billboard.Context
{
    public class BilllboardDBContext : DbContext
    {
        public BilllboardDBContext(DbContextOptions options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

        }
        public DbSet<User> Users { get; set; }
    }

}
