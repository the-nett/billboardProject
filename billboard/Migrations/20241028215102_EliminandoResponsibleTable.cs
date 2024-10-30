using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class EliminandoResponsibleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Responsibles_IdResponsible",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "Responsibles");

            migrationBuilder.DropIndex(
                name: "IX_Companies_IdResponsible",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IdResponsible",
                table: "Companies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdResponsible",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Responsibles",
                columns: table => new
                {
                    IdResponsible = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_People = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IdResponsible",
                table: "Companies",
                column: "IdResponsible",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responsibles_Id_People",
                table: "Responsibles",
                column: "Id_People",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Responsibles_IdResponsible",
                table: "Companies",
                column: "IdResponsible",
                principalTable: "Responsibles",
                principalColumn: "IdResponsible");
        }
    }
}
