using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModifyByPerson",
                table: "UserHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyByPerson",
                table: "UserHistories");
        }
    }
}
