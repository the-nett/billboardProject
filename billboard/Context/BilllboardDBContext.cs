using billboard.Model;
using Microsoft.EntityFrameworkCore;

namespace billboard.Context
{
    public class BilllboardDBContext : DbContext
    {
        public BilllboardDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Rental> Rental { get; set; }   
        public DbSet<Billboard> Billboards { get; set; } 
        public DbSet<BillboardType> BillboardTypes { get; set; } 
        public DbSet<BillboardState> BillboardStates { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Responsible> Responsibles { get;   set; }  
        public DbSet<Tenant> Tenants { get; set; }  
        public DbSet<PayMethods> PayMethods { get; set; }
        public DbSet<UserTypePermissions> UserTypePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserType> UserTypes { get; set; } 
        public DbSet<Lessor> Lessors { get; set; }
    }

}
