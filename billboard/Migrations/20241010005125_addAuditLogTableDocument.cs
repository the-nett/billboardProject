using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class addAuditLogTableDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TABLE DocumentAuditLog (
                IdAuditLog INT PRIMARY KEY IDENTITY(1,1),
                DocumentId INT,
                DocumentName NVARCHAR(255),
                Operation NVARCHAR(50),
                OperationDate DATETIME DEFAULT GETDATE()
            );
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE DocumentAuditLog");
        }
    }
}
