using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class UnoAMuchosBillboardXRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Tenants_IdLessor",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_IdBillboard",
                table: "Rentals");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IdBillboard",
                table: "Rentals",
                column: "IdBillboard");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IdTenant",
                table: "Rentals",
                column: "IdTenant");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Tenants_IdTenant",
                table: "Rentals",
                column: "IdTenant",
                principalTable: "Tenants",
                principalColumn: "IdTenant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Tenants_IdTenant",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_IdBillboard",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_IdTenant",
                table: "Rentals");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IdBillboard",
                table: "Rentals",
                column: "IdBillboard",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Tenants_IdLessor",
                table: "Rentals",
                column: "IdLessor",
                principalTable: "Tenants",
                principalColumn: "IdTenant");
        }
    }
}
