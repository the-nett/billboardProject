using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditLogTableCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TABLE CompanyAuditLog (
                IdAuditLog INT PRIMARY KEY IDENTITY(1,1),
                IdCompany INT,
                Company_Name NVARCHAR(255),
                Owner_Name NVARCHAR(255),
                Operation NVARCHAR(50),
                OperationDate DATETIME DEFAULT GETDATE()
            );
        ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE CompanyAuditLog");

        }
    }
}
