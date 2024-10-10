using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class addAuditInsertTrigger_Document_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER trg_AuditLogOnUpdate_Document
            ON dbo.Documents
            AFTER UPDATE
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO DocumentAuditLog (DocumentId, DocumentName, Operation)
                SELECT 
                    i.DocumentId, 
                    i.DocumentName, 
                    'UPDATE'
                FROM 
                    inserted i;
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AuditLogOnUpdate_Document");
        }
    }
}
