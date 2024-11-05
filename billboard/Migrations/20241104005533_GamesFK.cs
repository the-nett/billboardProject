using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class GamesFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Games_IdUser",
                table: "Games",
                column: "IdUser",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_IdUser",
                table: "Games",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_IdUser",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_IdUser",
                table: "Games");
        }
    }
}
