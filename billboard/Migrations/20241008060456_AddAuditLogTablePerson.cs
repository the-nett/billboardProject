using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditLogTablePerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TABLE PersonAuditLog (
                IdAuditLog INT PRIMARY KEY IDENTITY(1,1),
                IdPeople INT,
                Name NVARCHAR(255),
                LastName NVARCHAR(255),
                DocumentNumb NVARCHAR(50),
                Operation NVARCHAR(50),
                OperationDate DATETIME DEFAULT GETDATE()
            );
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AuditLogOnInsert_Person");

        }
    }
}
