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

            // OnmodelCreating UserTypePermissions
            var userTypePermisions = modelBuilder.Entity<UserTypePermissions>();
            
            userTypePermisions.HasKey(Utp => new { Utp.Id_permission, Utp.Id_Usertype}); 

            userTypePermisions.HasOne(Utp => Utp.Permission).WithMany(x => x.UserTypePermission).HasForeignKey(Utp => Utp.Id_permission);
            userTypePermisions.HasOne(Utp => Utp.UserType).WithMany(x => x.UserTypes).HasForeignKey(Utp => Utp.Id_Usertype);

            //userTypePermisions.HasNoKey();

            // OnmodelCreating Responsible
            var responsible = modelBuilder.Entity<Responsible>();

            responsible.HasKey(x => x.IdResponsible);

            responsible.HasOne(x => x.Person).WithOne(x => x.Responsible).HasForeignKey<Responsible>(x => x.Id_People).OnDelete(DeleteBehavior.NoAction);
            responsible.HasOne(x => x.Company).WithOne(x => x.Responsible).HasForeignKey<Responsible>(x => x.CompanyId).OnDelete(DeleteBehavior.NoAction);

            // OnmodelCreating User
            var user = modelBuilder.Entity<User>();

            user.HasKey(x => x.IdUser);
            user.HasOne(x => x.Person).WithOne(x => x.User).HasForeignKey<User>(x => x.PeopleId).OnDelete(DeleteBehavior.NoAction);
            user.HasOne(x => x.UserType).WithMany(x => x.Users).HasForeignKey(x => x.IdUserType).OnDelete(DeleteBehavior.NoAction);

            // OnmodelCreating Person
            var person = modelBuilder.Entity<Person>();

            person.HasKey(x => x.IdPeople);
            person.HasOne(x => x.UserType).WithMany(x => x.People).HasForeignKey(x => x.IdUserType).OnDelete(DeleteBehavior.NoAction);
            person.HasOne(x => x.Document).WithMany(x => x.Documents).HasForeignKey(x => x.IdDocumentType).OnDelete(DeleteBehavior.NoAction);

            // OnmodelCreating Company
            var compnay = modelBuilder.Entity<Company>();

            compnay.HasKey(x => x.IdCompany);
            compnay.HasOne(x => x.Industry).WithMany(x => x.Companies).HasForeignKey(x => x.IdIndustry).OnDelete(DeleteBehavior.NoAction);
            compnay.HasOne(x => x.City).WithMany(x => x.CitiesCompany).HasForeignKey(x => x.IdCity).OnDelete(DeleteBehavior.NoAction);
            compnay.HasOne(x => x.Responsible).WithOne(x => x.Company).HasForeignKey<Company>(x => x.IdResponsible).OnDelete(DeleteBehavior.NoAction);
            compnay.HasOne(x => x.UserType).WithMany(x => x.UserTypeCompany).HasForeignKey(x => x.Id_User_Type).OnDelete(DeleteBehavior.NoAction);

            // OnmodelCreating Rental
            var rental = modelBuilder.Entity<Rental>();
            rental.HasKey(x => x.IdRental);

            rental.HasOne(x => x.Billboard).WithOne(x => x.Rental).HasForeignKey<Rental>(x => x.IdBillboard).OnDelete(DeleteBehavior.NoAction);
            rental.HasOne(x => x.Lessor).WithMany(x => x.Lessor_Rental).HasForeignKey(x => x.IdLessor).OnDelete(DeleteBehavior.NoAction);
            rental.HasOne(x => x.Tenant).WithMany(x => x.Tenant_Rental).HasForeignKey(x => x.IdLessor).OnDelete(DeleteBehavior.NoAction);
            rental.HasOne(x => x.PayMethods).WithMany(x => x.PayMethodsRental).HasForeignKey(x => x.IdPayMethods).OnDelete(DeleteBehavior.NoAction);

            // OnmodelCreating Billboard
            var billboard = modelBuilder.Entity<Billboard>();
            billboard.HasKey(x => x.IdBillboard);

            billboard.HasOne(x => x.Lessor).WithMany(x => x.Lessor_Billboard).HasForeignKey(x => x.IdLessor).OnDelete(DeleteBehavior.NoAction);
            billboard.HasOne(x => x.BillboardState).WithMany(x => x.BillboardState_Billboard).HasForeignKey(x => x.IdBillboardState).OnDelete(DeleteBehavior.NoAction);
            billboard.HasOne(x => x.BillboardType).WithMany(x => x.BillboardType_Billboard).HasForeignKey(x => x.IdBillboardType).OnDelete(DeleteBehavior.NoAction);

            // OnmodelCreating BillboardType
            var billboard_type = modelBuilder.Entity<BillboardType>();
            billboard_type.HasKey(x => x.BillboardTypeId);

            // OnmodelCreating BillboardState
            var billboard_state = modelBuilder.Entity<BillboardState>();
            billboard_state.HasKey(x => x.IdSate);

            // OnmodelCreating City
            var city = modelBuilder.Entity<City>();
            city.HasKey(x => x.CityId);

            // OnmodelCreating Document
            var document = modelBuilder.Entity<Document>();
            document.HasKey(x => x.DocumentId);

            // OnmodelCreating Industry
            var industry = modelBuilder.Entity<Industry>();
            industry.HasKey(x => x.IndustryId);

            // OnmodelCreating Tenant
            var tenant = modelBuilder.Entity<Tenant>();
            tenant.HasKey(x => x.IdTenant);
            tenant.HasOne(x => x.UserType).WithMany(x => x.UserTypeTenant).HasForeignKey(x => x.IdUserType).OnDelete(DeleteBehavior.NoAction);

            // OnmodelCreating PayMethods
            var pay_methods = modelBuilder.Entity<PayMethods>();
            pay_methods.HasKey(x => x.IdPayMethod);

            // OnmodelCreating Permission
            var permissions = modelBuilder.Entity<Permission>();
            permissions.HasKey(x => x.Id_Permission);

            // OnmodelCreating UserType
            var user_type = modelBuilder.Entity<UserType>();
            user_type.HasKey(x => x.Id_Usertype);

            // OnmodelCreating Lessor
            var lessor = modelBuilder.Entity<Lessor>();
            lessor.HasKey(x => x.IdLessor);
            lessor.HasOne(x => x.UserType).WithMany(x => x.UserTypeLessor).HasForeignKey(x => x.IdUserType).OnDelete(DeleteBehavior.NoAction);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Billboard> Billboards { get; set; }
        public DbSet<BillboardType> BillboardTypes { get; set; }
        public DbSet<BillboardState> BillboardStates { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Responsible> Responsibles { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<PayMethods> PayMethods { get; set; }
        public DbSet<UserTypePermissions> UserTypePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Lessor> Lessors { get; set; }
    }
}

