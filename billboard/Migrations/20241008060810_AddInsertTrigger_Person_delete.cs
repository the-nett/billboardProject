using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddInsertTrigger_Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER trg_AuditLogOnDelete_Person
            ON dbo.People
            AFTER DELETE
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO PersonAuditLog (IdPeople, Name, LastName, DocumentNumb, Operation)
                SELECT 
                    d.IdPeople, 
                    d.Name, 
                    d.LastName, 
                    d.DocumentNumb, 
                    'DELETE'
                FROM 
                    deleted d;
            END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AuditLogOnDelete_Person");
        }
    }
}
