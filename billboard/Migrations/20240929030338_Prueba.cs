using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class Prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsibles_Companies_Company_Id",
                table: "Responsibles");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsibles_People_Id_People",
                table: "Responsibles");

            migrationBuilder.DropIndex(
                name: "IX_Responsibles_Company_Id",
                table: "Responsibles");

            migrationBuilder.DropIndex(
                name: "IX_Responsibles_CompanyId",
                table: "Responsibles");

            migrationBuilder.DropIndex(
                name: "IX_Responsibles_Id_People",
                table: "Responsibles");

            migrationBuilder.DropColumn(
                name: "Company_Id",
                table: "Responsibles");

            migrationBuilder.CreateIndex(
                name: "IX_Responsibles_CompanyId",
                table: "Responsibles",
                column: "CompanyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Responsibles_CompanyId",
                table: "Responsibles");

            migrationBuilder.AddColumn<int>(
                name: "Company_Id",
                table: "Responsibles",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibles_Companies_Company_Id",
                table: "Responsibles",
                column: "Company_Id",
                principalTable: "Companies",
                principalColumn: "Company_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibles_People_Id_People",
                table: "Responsibles",
                column: "Id_People",
                principalTable: "People",
                principalColumn: "PeopleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
