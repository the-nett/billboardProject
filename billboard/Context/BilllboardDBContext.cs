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

            //OnmodelCreating UserTypePermissions
            var userTypePermisions = modelBuilder.Entity<UserTypePermissions>();

            userTypePermisions.Property(x => x.Id_Usertype).IsRequired();
            userTypePermisions.Property(x => x.Id_permission).IsRequired();

            //OnmodelCreating Responsible
            var responsible = modelBuilder.Entity<Responsible>();

            responsible.HasKey(x => x.ResponsibleId); //LLave primaria

            responsible.HasOne(x => x.Person).WithOne(x => x.Responsible).HasForeignKey<Responsible>(x => x.Id_People).OnDelete(DeleteBehavior.NoAction);
            responsible.HasOne(x => x.Company).WithOne(x => x.Responsible).HasForeignKey<Responsible>(x => x.CompanyId).OnDelete(DeleteBehavior.NoAction);


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
