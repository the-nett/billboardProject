using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class TryingsolveproblemwithforeingKinResponsiblecs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonPeopleId",
                table: "Responsibles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Responsibles_PersonPeopleId",
                table: "Responsibles",
                column: "PersonPeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibles_People_PersonPeopleId",
                table: "Responsibles",
                column: "PersonPeopleId",
                principalTable: "People",
                principalColumn: "PeopleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsibles_People_PersonPeopleId",
                table: "Responsibles");

            migrationBuilder.DropIndex(
                name: "IX_Responsibles_PersonPeopleId",
                table: "Responsibles");

            migrationBuilder.DropColumn(
                name: "PersonPeopleId",
                table: "Responsibles");
        }
    }
}
