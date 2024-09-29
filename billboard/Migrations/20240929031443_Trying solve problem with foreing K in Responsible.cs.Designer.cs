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
    [Migration("20240929031443_Trying solve problem with foreing K in Responsible.cs")]
    partial class TryingsolveproblemwithforeingKinResponsiblecs
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
                    b.Property<int>("BillboardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillboardId"));

                    b.Property<int>("BillboardStateId")
                        .HasColumnType("int");

                    b.Property<int>("BillboardTypeId")
                        .HasColumnType("int");

                    b.Property<double>("Fee")
                        .HasColumnType("float");

                    b.Property<double>("FloorDistance")
                        .HasColumnType("float");

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

                    b.Property<int>("LessorId")
                        .HasColumnType("int");

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

                    b.HasKey("BillboardId");

                    b.HasIndex("BillboardStateId");

                    b.HasIndex("BillboardTypeId");

                    b.ToTable("Billboards");
                });

            modelBuilder.Entity("billboard.Model.BillboardState", b =>
                {
                    b.Property<int>("Sate_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sate_Id"));

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sate_Id");

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

                    b.HasKey("BillboardTypeId");

                    b.ToTable("BillboardTypes");
                });

            modelBuilder.Entity("billboard.Model.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<int>("CatalogId")
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Citys");
                });

            modelBuilder.Entity("billboard.Model.Company", b =>
                {
                    b.Property<int>("Company_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Company_Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("City_Id")
                        .HasColumnType("int");

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

                    b.Property<int>("Id_User_Type")
                        .HasColumnType("int");

                    b.Property<int>("IndustryId")
                        .HasColumnType("int");

                    b.Property<int>("Industry_Id")
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

                    b.Property<int>("Responsible_Id")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId_Usertype")
                        .HasColumnType("int");

                    b.HasKey("Company_Id");

                    b.HasIndex("CityId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("UserTypeId_Usertype");

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

                    b.HasKey("IndustryId");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("billboard.Model.Lessor", b =>
                {
                    b.Property<int>("LessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessorId"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("LessorId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Lessors");
                });

            modelBuilder.Entity("billboard.Model.PayMethods", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantId"));

                    b.Property<string>("PayMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TenantId");

                    b.ToTable("PayMethods");
                });

            modelBuilder.Entity("billboard.Model.Permission", b =>
                {
                    b.Property<int>("Id_Permission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Permission"));

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Permission");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("billboard.Model.Person", b =>
                {
                    b.Property<int>("PeopleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeopleId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("DocumentNumb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("PeopleId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("billboard.Model.Rental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalId"));

                    b.Property<string>("AdContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BillboardId")
                        .HasColumnType("int");

                    b.Property<string>("ContractClauses")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessorId")
                        .HasColumnType("int");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PayMethodsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("RentalId");

                    b.HasIndex("BillboardId");

                    b.HasIndex("LessorId");

                    b.HasIndex("PayMethodsId");

                    b.HasIndex("TenantId");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("billboard.Model.Responsible", b =>
                {
                    b.Property<int>("ResponsibleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResponsibleId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("Id_People")
                        .HasColumnType("int");

                    b.Property<int>("PersonPeopleId")
                        .HasColumnType("int");

                    b.HasKey("ResponsibleId");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.HasIndex("PersonPeopleId");

                    b.ToTable("Responsibles");
                });

            modelBuilder.Entity("billboard.Model.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantId"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("TenantId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("billboard.Model.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

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

                    b.Property<int>("PersonPeopleId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId_Usertype")
                        .HasColumnType("int");

                    b.HasKey("User_Id");

                    b.HasIndex("PersonPeopleId");

                    b.HasIndex("UserTypeId_Usertype");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("billboard.Model.UserType", b =>
                {
                    b.Property<int>("Id_Usertype")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Usertype"));

                    b.Property<string>("Utype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Usertype");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("billboard.Model.UserTypePermissions", b =>
                {
                    b.Property<int>("IdId_permission")
                        .HasColumnType("int");

                    b.Property<int>("Id_Usertype")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId_Permission")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId_Usertype")
                        .HasColumnType("int");

                    b.HasIndex("PermissionId_Permission");

                    b.HasIndex("UserTypeId_Usertype");

                    b.ToTable("UserTypePermissions");
                });

            modelBuilder.Entity("billboard.Model.Billboard", b =>
                {
                    b.HasOne("billboard.Model.BillboardState", "BillboardState")
                        .WithMany()
                        .HasForeignKey("BillboardStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.BillboardType", "BillboardType")
                        .WithMany()
                        .HasForeignKey("BillboardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BillboardState");

                    b.Navigation("BillboardType");
                });

            modelBuilder.Entity("billboard.Model.Company", b =>
                {
                    b.HasOne("billboard.Model.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId_Usertype")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Industry");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.Lessor", b =>
                {
                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.Person", b =>
                {
                    b.HasOne("billboard.Model.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.Rental", b =>
                {
                    b.HasOne("billboard.Model.Billboard", "Billboard")
                        .WithMany()
                        .HasForeignKey("BillboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.Lessor", "Lessor")
                        .WithMany()
                        .HasForeignKey("LessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.PayMethods", "PayMethods")
                        .WithMany()
                        .HasForeignKey("PayMethodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billboard");

                    b.Navigation("Lessor");

                    b.Navigation("PayMethods");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("billboard.Model.Responsible", b =>
                {
                    b.HasOne("billboard.Model.Company", "Company")
                        .WithOne("Responsible")
                        .HasForeignKey("billboard.Model.Responsible", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonPeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("billboard.Model.Tenant", b =>
                {
                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.User", b =>
                {
                    b.HasOne("billboard.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonPeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId_Usertype")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.UserTypePermissions", b =>
                {
                    b.HasOne("billboard.Model.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId_Permission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("billboard.Model.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId_Usertype")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("billboard.Model.Company", b =>
                {
                    b.Navigation("Responsible")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
