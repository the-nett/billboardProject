using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddStateDeleteToAllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "UserTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "UserTypePermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Responsibles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Rentals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "PayMethods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Lessors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Industries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Documents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "BillboardTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "BillboardStates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Billboards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "UserTypePermissions");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Responsibles");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "PayMethods");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Lessors");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Industries");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "BillboardTypes");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "BillboardStates");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Billboards");
        }
    }
}
