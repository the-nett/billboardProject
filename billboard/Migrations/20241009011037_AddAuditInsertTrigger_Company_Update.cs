using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditInsertTrigger_Company_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER trg_AuditLogOnUpdate_Company
            ON dbo.Companies
            AFTER UPDATE
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO CompanyAuditLog (IdCompany, Company_Name, Owner_Name, Operation)
                SELECT 
                    i.IdCompany, 
                    i.Company_Name, 
                    i.Owner_Name, 
                    'UPDATE'
                FROM 
                    inserted i;
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AuditLogOnUpdate_Company");
        }
    }
}
