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
                    Sate_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillboardStates", x => x.Sate_Id);
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
                name: "PayMethods",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayMethods", x => x.TenantId);
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
                    BillboardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessorId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false),
                    BillboardStateId = table.Column<int>(type: "int", nullable: false),
                    LatitudeAndLongitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillboardTypeId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Billboards", x => x.BillboardId);
                    table.ForeignKey(
                        name: "FK_Billboards_BillboardStates_BillboardStateId",
                        column: x => x.BillboardStateId,
                        principalTable: "BillboardStates",
                        principalColumn: "Sate_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Billboards_BillboardTypes_BillboardTypeId",
                        column: x => x.BillboardTypeId,
                        principalTable: "BillboardTypes",
                        principalColumn: "BillboardTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Company_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry_Id = table.Column<int>(type: "int", nullable: false),
                    NIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Corporate_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsible_Id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_User_Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId_Usertype = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Company_Id);
                    table.ForeignKey(
                        name: "FK_Companies_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "IndustryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_UserTypes_UserTypeId_Usertype",
                        column: x => x.UserTypeId_Usertype,
                        principalTable: "UserTypes",
                        principalColumn: "Id_Usertype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessors",
                columns: table => new
                {
                    LessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessors", x => x.LessorId);
                    table.ForeignKey(
                        name: "FK_Lessors_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id_Usertype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentNumb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PeopleId);
                    table.ForeignKey(
                        name: "FK_People_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id_Usertype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantId);
                    table.ForeignKey(
                        name: "FK_Tenants_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id_Usertype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTypePermissions",
                columns: table => new
                {
                    IdId_permission = table.Column<int>(type: "int", nullable: false),
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
                name: "Responsibles",
                columns: table => new
                {
                    ResponsibleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_People = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Company_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => x.ResponsibleId);
                    table.ForeignKey(
                        name: "FK_Responsibles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responsibles_Companies_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Companies",
                        principalColumn: "Company_Id");
                    table.ForeignKey(
                        name: "FK_Responsibles_People_Id_People",
                        column: x => x.Id_People,
                        principalTable: "People",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    PeoplePassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeopleSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUserType = table.Column<int>(type: "int", nullable: false),
                    PersonPeopleId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId_Usertype = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_Users_People_PersonPeopleId",
                        column: x => x.PersonPeopleId,
                        principalTable: "People",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId_Usertype",
                        column: x => x.UserTypeId_Usertype,
                        principalTable: "UserTypes",
                        principalColumn: "Id_Usertype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillboardId = table.Column<int>(type: "int", nullable: false),
                    LessorId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayMethodsId = table.Column<int>(type: "int", nullable: false),
                    AdContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractClauses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rental_Billboards_BillboardId",
                        column: x => x.BillboardId,
                        principalTable: "Billboards",
                        principalColumn: "BillboardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_Lessors_LessorId",
                        column: x => x.LessorId,
                        principalTable: "Lessors",
                        principalColumn: "LessorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_PayMethods_PayMethodsId",
                        column: x => x.PayMethodsId,
                        principalTable: "PayMethods",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Billboards_BillboardStateId",
                table: "Billboards",
                column: "BillboardStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Billboards_BillboardTypeId",
                table: "Billboards",
                column: "BillboardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityId",
                table: "Companies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IndustryId",
                table: "Companies",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserTypeId_Usertype",
                table: "Companies",
                column: "UserTypeId_Usertype");

            migrationBuilder.CreateIndex(
                name: "IX_Lessors_UserTypeId",
                table: "Lessors",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_People_DocumentId",
                table: "People",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_People_UserTypeId",
                table: "People",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_BillboardId",
                table: "Rental",
                column: "BillboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_LessorId",
                table: "Rental",
                column: "LessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_PayMethodsId",
                table: "Rental",
                column: "PayMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_TenantId",
                table: "Rental",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsibles_Company_Id",
                table: "Responsibles",
                column: "Company_Id",
                unique: true,
                filter: "[Company_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Responsibles_CompanyId",
                table: "Responsibles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsibles_Id_People",
                table: "Responsibles",
                column: "Id_People");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_UserTypeId",
                table: "Tenants",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonPeopleId",
                table: "Users",
                column: "PersonPeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId_Usertype",
                table: "Users",
                column: "UserTypeId_Usertype");

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
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Responsibles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypePermissions");

            migrationBuilder.DropTable(
                name: "Billboards");

            migrationBuilder.DropTable(
                name: "Lessors");

            migrationBuilder.DropTable(
                name: "PayMethods");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "BillboardStates");

            migrationBuilder.DropTable(
                name: "BillboardTypes");

            migrationBuilder.DropTable(
                name: "Citys");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
