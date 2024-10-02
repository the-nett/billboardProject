using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillboardStates",
                columns: table => new
                {
                    IdSate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillboardStates", x => x.IdSate);
                });

            migrationBuilder.CreateTable(
                name: "BillboardTypes",
                columns: table => new
                {
                    BillboardTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillboardTypet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillboardTypes", x => x.BillboardTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    IndustryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "Lessors",
                columns: table => new
                {
                    IdLessor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdUserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessors", x => x.IdLessor);
                });

            migrationBuilder.CreateTable(
                name: "PayMethods",
                columns: table => new
                {
                    IdPayMethod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMethods", x => x.IdPayMethod);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id_Permission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permissions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id_Permission);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    IdTenant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.IdTenant);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id_Usertype = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id_Usertype);
                });

            migrationBuilder.CreateTable(
                name: "Billboards",
                columns: table => new
                {
                    IdBillboard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLessor = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false),
                    IdBillboardState = table.Column<int>(type: "int", nullable: false),
                    LatitudeAndLongitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdBillboardType = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Measures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorDistance = table.Column<double>(type: "float", nullable: false),
                    Illumination = table.Column<bool>(type: "bit", nullable: false),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SimultaneousAds = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billboards", x => x.IdBillboard);
                    table.ForeignKey(
                        name: "FK_Billboards_BillboardStates_IdBillboardState",
                        column: x => x.IdBillboardState,
                        principalTable: "BillboardStates",
                        principalColumn: "IdSate");
                    table.ForeignKey(
                        name: "FK_Billboards_BillboardTypes_IdBillboardType",
                        column: x => x.IdBillboardType,
                        principalTable: "BillboardTypes",
                        principalColumn: "BillboardTypeId");
                    table.ForeignKey(
                        name: "FK_Billboards_Lessors_IdLessor",
                        column: x => x.IdLessor,
                        principalTable: "Lessors",
                        principalColumn: "IdLessor");
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    IdPeople = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentNumb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUserType = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.IdPeople);
                    table.ForeignKey(
                        name: "FK_People_Documents_IdDocumentType",
                        column: x => x.IdDocumentType,
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                    table.ForeignKey(
                        name: "FK_People_UserTypes_IdUserType",
                        column: x => x.IdUserType,
                        principalTable: "UserTypes",
                        principalColumn: "Id_Usertype");
                });

            migrationBuilder.CreateTable(
                name: "UserTypePermissions",
                columns: table => new
                {
                    Id_permission = table.Column<int>(type: "int", nullable: false),
                    Id_Usertype = table.Column<int>(type: "int", nullable: false),
                    UserTypeId_Usertype = table.Column<int>(type: "int", nullable: false),
                    PermissionId_Permission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_UserTypePermissions_Permissions_PermissionId_Permission",
                        column: x => x.PermissionId_Permission,
                        principalTable: "Permissions",
                        principalColumn: "Id_Permission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTypePermissions_UserTypes_UserTypeId_Usertype",
                        column: x => x.UserTypeId_Usertype,
                        principalTable: "UserTypes",
                        principalColumn: "Id_Usertype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    IdRental = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBillboard = table.Column<int>(type: "int", nullable: false),
                    IdLessor = table.Column<int>(type: "int", nullable: false),
                    IdTenant = table.Column<int>(type: "int", nullable: false),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPayMethods = table.Column<int>(type: "int", nullable: false),
                    AdContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractClauses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.IdRental);
                    table.ForeignKey(
                        name: "FK_Rentals_Billboards_IdBillboard",
                        column: x => x.IdBillboard,
                        principalTable: "Billboards",
                        principalColumn: "IdBillboard");
                    table.ForeignKey(
                        name: "FK_Rentals_Lessors_IdLessor",
                        column: x => x.IdLessor,
                        principalTable: "Lessors",
                        principalColumn: "IdLessor");
                    table.ForeignKey(
                        name: "FK_Rentals_PayMethods_IdPayMethods",
                        column: x => x.IdPayMethods,
                        principalTable: "PayMethods",
                        principalColumn: "IdPayMethod");
                    table.ForeignKey(
                        name: "FK_Rentals_Tenants_IdLessor",
                        column: x => x.IdLessor,
                        principalTable: "Tenants",
                        principalColumn: "IdTenant");
                });

            migrationBuilder.CreateTable(
                name: "Responsibles",
                columns: table => new
                {
                    IdResponsible = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_People = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => x.IdResponsible);
                    table.ForeignKey(
                        name: "FK_Responsibles_People_Id_People",
                        column: x => x.Id_People,
                        principalTable: "People",
                        principalColumn: "IdPeople");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    PeoplePassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeopleSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "IdPeople");
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_IdUserType",
                        column: x => x.IdUserType,
                        principalTable: "UserTypes",
                        principalColumn: "Id_Usertype");
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdIndustry = table.Column<int>(type: "int", nullable: false),
                    NIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Corporate_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdResponsible = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_User_Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.IdCompany);
                    table.ForeignKey(
                        name: "FK_Companies_Citys_IdCity",
                        column: x => x.IdCity,
                        principalTable: "Citys",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_Companies_Industries_IdIndustry",
                        column: x => x.IdIndustry,
                        principalTable: "Industries",
                        principalColumn: "IndustryId");
                    table.ForeignKey(
                        name: "FK_Companies_Responsibles_IdResponsible",
                        column: x => x.IdResponsible,
                        principalTable: "Responsibles",
                        principalColumn: "IdResponsible");
                    table.ForeignKey(
                        name: "FK_Companies_UserTypes_Id_User_Type",
                        column: x => x.Id_User_Type,
                        principalTable: "UserTypes",
                        principalColumn: "Id_Usertype");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Billboards_IdBillboardState",
                table: "Billboards",
                column: "IdBillboardState");

            migrationBuilder.CreateIndex(
                name: "IX_Billboards_IdBillboardType",
                table: "Billboards",
                column: "IdBillboardType");

            migrationBuilder.CreateIndex(
                name: "IX_Billboards_IdLessor",
                table: "Billboards",
                column: "IdLessor");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Id_User_Type",
                table: "Companies",
                column: "Id_User_Type");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IdCity",
                table: "Companies",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IdIndustry",
                table: "Companies",
                column: "IdIndustry");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IdResponsible",
                table: "Companies",
                column: "IdResponsible",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_IdDocumentType",
                table: "People",
                column: "IdDocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_People_IdUserType",
                table: "People",
                column: "IdUserType");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IdBillboard",
                table: "Rentals",
                column: "IdBillboard",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IdLessor",
                table: "Rentals",
                column: "IdLessor");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IdPayMethods",
                table: "Rentals",
                column: "IdPayMethods");

            migrationBuilder.CreateIndex(
                name: "IX_Responsibles_Id_People",
                table: "Responsibles",
                column: "Id_People",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdUserType",
                table: "Users",
                column: "IdUserType");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PeopleId",
                table: "Users",
                column: "PeopleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTypePermissions_PermissionId_Permission",
                table: "UserTypePermissions",
                column: "PermissionId_Permission");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypePermissions_UserTypeId_Usertype",
                table: "UserTypePermissions",
                column: "UserTypeId_Usertype");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypePermissions");

            migrationBuilder.DropTable(
                name: "Citys");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "Responsibles");

            migrationBuilder.DropTable(
                name: "Billboards");

            migrationBuilder.DropTable(
                name: "PayMethods");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "BillboardStates");

            migrationBuilder.DropTable(
                name: "BillboardTypes");

            migrationBuilder.DropTable(
                name: "Lessors");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
