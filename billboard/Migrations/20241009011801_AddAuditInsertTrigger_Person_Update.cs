using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditInsertTrigger_Person_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER trg_AuditLogOnUpdate_Person
            ON dbo.People
            AFTER UPDATE
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO PersonAuditLog (IdPeople, Name, LastName, DocumentNumb, Operation)
                SELECT 
                    i.IdPeople, 
                    i.Name, 
                    i.LastName, 
                    i.DocumentNumb, 
                    'UPDATE'
                FROM 
                    inserted i;
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AuditLogOnUpdate_Person");
        }
    }
}
