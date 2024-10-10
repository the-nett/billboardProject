using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditLogTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TABLE UserAuditLog (
                IdAuditLog INT PRIMARY KEY IDENTITY(1,1),
                IdUser INT,
                PeopleId INT,
                PeoplePassword NVARCHAR(255),
                Operation NVARCHAR(50),
                OperationDate DATETIME DEFAULT GETDATE()
            );
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AuditLogOnInsert_User");

        }
    }
}
