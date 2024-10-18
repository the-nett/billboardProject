using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class addAuditInsertTrigger_Document_delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER trg_AuditLogOnDelete_Document
            ON dbo.Documents
            AFTER DELETE
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO DocumentAuditLog (DocumentId, DocumentName, Operation)
                SELECT 
                    d.DocumentId, 
                    d.DocumentName, 
                    'DELETE'
                FROM 
                    deleted d;
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AuditLogOnDelete_Document");
        }
    }
}
