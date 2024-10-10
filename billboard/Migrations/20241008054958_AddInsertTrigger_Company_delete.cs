using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddInsertTrigger_Company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER trg_AuditLogOnDelete_Company
            ON dbo.Companies
            AFTER DELETE
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO CompanyAuditLog (IdCompany, Company_Name, Owner_Name, Operation)
                SELECT 
                    d.IdCompany, 
                    d.Company_Name, 
                    d.Owner_Name, 
                    'DELETE'
                FROM 
                    deleted d;
            END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AuditLogOnDelete_Company");
        }
    }
}
