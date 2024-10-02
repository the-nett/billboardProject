using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AjusteenrelacionTennantyLessor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "Tenants",
                newName: "IdUserType");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_IdUserType",
                table: "Tenants",
                column: "IdUserType");

            migrationBuilder.CreateIndex(
                name: "IX_Lessors_IdUserType",
                table: "Lessors",
                column: "IdUserType");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessors_UserTypes_IdUserType",
                table: "Lessors",
                column: "IdUserType",
                principalTable: "UserTypes",
                principalColumn: "Id_Usertype");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_UserTypes_IdUserType",
                table: "Tenants",
                column: "IdUserType",
                principalTable: "UserTypes",
                principalColumn: "Id_Usertype");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessors_UserTypes_IdUserType",
                table: "Lessors");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_UserTypes_IdUserType",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_IdUserType",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Lessors_IdUserType",
                table: "Lessors");

            migrationBuilder.RenameColumn(
                name: "IdUserType",
                table: "Tenants",
                newName: "UserTypeId");
        }
    }
}
