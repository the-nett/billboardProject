using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AjustederelacionesyFKparaUserTypePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTypePermissions_Permissions_PermissionId_Permission",
                table: "UserTypePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTypePermissions_UserTypes_UserTypeId_Usertype",
                table: "UserTypePermissions");

            migrationBuilder.DropIndex(
                name: "IX_UserTypePermissions_PermissionId_Permission",
                table: "UserTypePermissions");

            migrationBuilder.DropIndex(
                name: "IX_UserTypePermissions_UserTypeId_Usertype",
                table: "UserTypePermissions");

            migrationBuilder.DropColumn(
                name: "PermissionId_Permission",
                table: "UserTypePermissions");

            migrationBuilder.DropColumn(
                name: "UserTypeId_Usertype",
                table: "UserTypePermissions");

            migrationBuilder.RenameColumn(
                name: "Permissions",
                table: "Permissions",
                newName: "Permission_");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypePermissions",
                table: "UserTypePermissions",
                columns: new[] { "Id_permission", "Id_Usertype" });

            migrationBuilder.CreateIndex(
                name: "IX_UserTypePermissions_Id_Usertype",
                table: "UserTypePermissions",
                column: "Id_Usertype");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypePermissions_Permissions_Id_permission",
                table: "UserTypePermissions",
                column: "Id_permission",
                principalTable: "Permissions",
                principalColumn: "Id_Permission",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypePermissions_UserTypes_Id_Usertype",
                table: "UserTypePermissions",
                column: "Id_Usertype",
                principalTable: "UserTypes",
                principalColumn: "Id_Usertype",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTypePermissions_Permissions_Id_permission",
                table: "UserTypePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTypePermissions_UserTypes_Id_Usertype",
                table: "UserTypePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypePermissions",
                table: "UserTypePermissions");

            migrationBuilder.DropIndex(
                name: "IX_UserTypePermissions_Id_Usertype",
                table: "UserTypePermissions");

            migrationBuilder.RenameColumn(
                name: "Permission_",
                table: "Permissions",
                newName: "Permissions");

            migrationBuilder.AddColumn<int>(
                name: "PermissionId_Permission",
                table: "UserTypePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId_Usertype",
                table: "UserTypePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserTypePermissions_PermissionId_Permission",
                table: "UserTypePermissions",
                column: "PermissionId_Permission");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypePermissions_UserTypeId_Usertype",
                table: "UserTypePermissions",
                column: "UserTypeId_Usertype");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypePermissions_Permissions_PermissionId_Permission",
                table: "UserTypePermissions",
                column: "PermissionId_Permission",
                principalTable: "Permissions",
                principalColumn: "Id_Permission",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypePermissions_UserTypes_UserTypeId_Usertype",
                table: "UserTypePermissions",
                column: "UserTypeId_Usertype",
                principalTable: "UserTypes",
                principalColumn: "Id_Usertype",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
