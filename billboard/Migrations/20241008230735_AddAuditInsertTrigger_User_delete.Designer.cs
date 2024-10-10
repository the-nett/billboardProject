﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using billboard.Context;

#nullable disable

namespace billboard.Migrations
{
    [DbContext(typeof(BilllboardDBContext))]
    [Migration("20241008230735_AddAuditInsertTrigger_User")]
    partial class AddAuditInsertTrigger_User
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("billboard.Model.Billboard", b =>
                {
                    b.Property<int>("IdBillboard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBillboard"));

                    b.Property<double>("Fee")
                        .HasColumnType("float");

                    b.Property<double>("FloorDistance")
                        .HasColumnType("float");

                    b.Property<int>("IdBillboardState")
                        .HasColumnType("int");

                    b.Property<int>("IdBillboardType")
                        .HasColumnType("int");

                    b.Property<int>("IdLessor")
                        .HasColumnType("int");

                    b.Property<bool>("Illumination")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InstallationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LatitudeAndLongitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Measures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SimultaneousAds")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdBillboard");

                    b.HasIndex("IdBillboardState");

                    b.HasIndex("IdBillboardType");

                    b.HasIndex("IdLessor");

                    b.ToTable("Billboards");
                });

            modelBuilder.Entity("billboard.Model.BillboardState", b =>
                {
                    b.Property<int>("IdSate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSate"));

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdSate");

                    b.ToTable("BillboardStates");
                });

            modelBuilder.Entity("billboard.Model.BillboardType", b =>
                {
                    b.Property<int>("BillboardTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillboardTypeId"));

                    b.Property<string>("BillboardTypet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("BillboardTypeId");

                    b.ToTable("BillboardTypes");
                });

            modelBuilder.Entity("billboard.Model.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("billboard.Model.Company", b =>
                {
                    b.Property<int>("IdCompany")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCompany"));

                    b.Property<string>("Company_Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Corporate_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCity")
                        .HasColumnType("int");

                    b.Property<int>("IdIndustry")
                        .HasColumnType("int");

                    b.Property<int>("IdResponsible")
                        .HasColumnType("int");

                    b.Property<int>("Id_User_Type")
                        .HasColumnType("int");

                    b.Property<string>("NIT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdCompany");

                    b.HasIndex("IdCity");

                    b.HasIndex("IdIndustry");

                    b.HasIndex("IdResponsible")
                        .IsUnique();

                    b.HasIndex("Id_User_Type");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("billboard.Model.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("billboard.Model.Industry", b =>
                {
                    b.Property<int>("IndustryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndustryId"));

                    b.Property<string>("IndustryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IndustryId");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("billboard.Model.Lessor", b =>
                {
                    b.Property<int>("IdLessor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLessor"));

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdUserType")
                        .HasColumnType("int");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdLessor");

                    b.HasIndex("IdUserType");

                    b.ToTable("Lessors");
                });

            modelBuilder.Entity("billboard.Model.PayMethods", b =>
                {
                    b.Property<int>("IdPayMethod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPayMethod"));

                    b.Property<string>("PayMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdPayMethod");

                    b.ToTable("PayMethods");
                });

            modelBuilder.Entity("billboard.Model.Permission", b =>
                {
                    b.Property<int>("Id_Permission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Permission"));

                    b.Property<string>("Permission_")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id_Permission");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("billboard.Model.Person", b =>
                {
                    b.Property<int>("IdPeople")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPeople"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentNumb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDocumentType")
                        .HasColumnType("int");

                    b.Property<int>("IdUserType")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPeople");

                    b.HasIndex("IdDocumentType");

                    b.HasIndex("IdUserType");

                    b.ToTable("People");
                });

            modelBuilder.Entity("billboard.Model.Rental", b =>
                {
                    b.Property<int>("IdRental")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRental"));

                    b.Property<string>("AdContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractClauses")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdBillboard")
                        .HasColumnType("int");

                    b.Property<int>("IdLessor")
                        .HasColumnType("int");

                    b.Property<int>("IdPayMethods")
                        .HasColumnType("int");

                    b.Property<int>("IdTenant")
                        .HasColumnType("int");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RentalEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalStartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdRental");

                    b.HasIndex("IdBillboard")
                        .IsUnique();

                    b.HasIndex("IdLessor");

                    b.HasIndex("IdPayMethods");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("billboard.Model.Responsible", b =>
                {
                    b.Property<int>("IdResponsible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResponsible"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("Id_People")
                        .HasColumnType("int");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdResponsible");

                    b.HasIndex("Id_People")
                        .IsUnique();

                    b.ToTable("Responsibles");
                });

            modelBuilder.Entity("billboard.Model.Tenant", b =>
                {
                    b.Property<int>("IdTenant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTenant"));

                    b.Property<int>("IdUserType")
                        .HasColumnType("int");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("IdTenant");

                    b.HasIndex("IdUserType");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("billboard.Model.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUserType")
                        .HasColumnType("int");

                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<string>("PeoplePassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeopleSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdUser");

                    b.HasIndex("IdUserType");

                    b.HasIndex("PeopleId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("billboard.Model.UserType", b =>
                {
                    b.Property<int>("Id_Usertype")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Usertype"));

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Utype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Usertype");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("billboard.Model.UserTypePermissions", b =>
                {
                    b.Property<int>("Id_permission")
                        .HasColumnType("int");

                    b.Property<int>("Id_Usertype")
                        .HasColumnType("int");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id_permission", "Id_Usertype");

                    b.HasIndex("Id_Usertype");

                    b.ToTable("UserTypePermissions");
                });

            modelBuilder.Entity("billboard.Model.Billboard", b =>
                {
                    b.HasOne("billboard.Model.BillboardState", "BillboardState")
                        .WithMany("BillboardState_Billboard")
                        .HasForeignKey("IdBillboardState")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("billboard.Model.BillboardType", "BillboardType")
                        .WithMany("BillboardType_Billboard")
                        .HasForeignKey("IdBillboardType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("billboard.Model.Lessor", "Lessor")
                        .WithMany("Lessor_Billboard")
                        .HasForeignKey("IdLessor")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BillboardState");

                    b.Navigation("BillboardType");

                    b.Navigation("Lessor");
                });

            modelBuilder.Entity("billboard.Model.Company", b =>
                {
                    b.HasOne("billboard.Model.City", "City")
                        .WithMany("CitiesCompany")
                        .HasForeignKey("IdCity")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("billboard.Model.Industry", "Industry")
                        .WithMany("Companies")
                        .HasForeignKey("IdIndustry")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("billboard.Model.Responsible", "Responsible")
                        .WithOne("Company")
                        .HasForeignKey("billboard.Model.Company", "IdResponsible")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany("UserTypeCompany")
                        .HasForeignKey("Id_User_Type")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Industry");

                    b.Navigation("Responsible");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.Lessor", b =>
                {
                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany("UserTypeLessor")
                        .HasForeignKey("IdUserType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.Person", b =>
                {
                    b.HasOne("billboard.Model.Document", "Document")
                        .WithMany("Documents")
                        .HasForeignKey("IdDocumentType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany("People")
                        .HasForeignKey("IdUserType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.Rental", b =>
                {
                    b.HasOne("billboard.Model.Billboard", "Billboard")
                        .WithOne("Rental")
                        .HasForeignKey("billboard.Model.Rental", "IdBillboard")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("billboard.Model.Lessor", "Lessor")
                        .WithMany("Lessor_Rental")
                        .HasForeignKey("IdLessor")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("billboard.Model.Tenant", "Tenant")
                        .WithMany("Tenant_Rental")
                        .HasForeignKey("IdLessor")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("billboard.Model.PayMethods", "PayMethods")
                        .WithMany("PayMethodsRental")
                        .HasForeignKey("IdPayMethods")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Billboard");

                    b.Navigation("Lessor");

                    b.Navigation("PayMethods");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("billboard.Model.Responsible", b =>
                {
                    b.HasOne("billboard.Model.Person", "Person")
                        .WithOne("Responsible")
                        .HasForeignKey("billboard.Model.Responsible", "Id_People")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("billboard.Model.Tenant", b =>
                {
                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany("UserTypeTenant")
                        .HasForeignKey("IdUserType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.User", b =>
                {
                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("IdUserType")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("billboard.Model.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("billboard.Model.User", "PeopleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.UserTypePermissions", b =>
                {
                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany("UserTypes")
                        .HasForeignKey("Id_Usertype")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.Permission", "Permission")
                        .WithMany("UserTypePermission")
                        .HasForeignKey("Id_permission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.Billboard", b =>
                {
                    b.Navigation("Rental")
                        .IsRequired();
                });

            modelBuilder.Entity("billboard.Model.BillboardState", b =>
                {
                    b.Navigation("BillboardState_Billboard");
                });

            modelBuilder.Entity("billboard.Model.BillboardType", b =>
                {
                    b.Navigation("BillboardType_Billboard");
                });

            modelBuilder.Entity("billboard.Model.City", b =>
                {
                    b.Navigation("CitiesCompany");
                });

            modelBuilder.Entity("billboard.Model.Document", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("billboard.Model.Industry", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("billboard.Model.Lessor", b =>
                {
                    b.Navigation("Lessor_Billboard");

                    b.Navigation("Lessor_Rental");
                });

            modelBuilder.Entity("billboard.Model.PayMethods", b =>
                {
                    b.Navigation("PayMethodsRental");
                });

            modelBuilder.Entity("billboard.Model.Permission", b =>
                {
                    b.Navigation("UserTypePermission");
                });

            modelBuilder.Entity("billboard.Model.Person", b =>
                {
                    b.Navigation("Responsible")
                        .IsRequired();

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("billboard.Model.Responsible", b =>
                {
                    b.Navigation("Company")
                        .IsRequired();
                });

            modelBuilder.Entity("billboard.Model.Tenant", b =>
                {
                    b.Navigation("Tenant_Rental");
                });

            modelBuilder.Entity("billboard.Model.UserType", b =>
                {
                    b.Navigation("People");

                    b.Navigation("UserTypeCompany");

                    b.Navigation("UserTypeLessor");

                    b.Navigation("UserTypeTenant");

                    b.Navigation("UserTypes");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
