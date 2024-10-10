using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditInsertTrigger_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER trg_AuditLogOnDelete_User
            ON dbo.[Users]
            AFTER DELETE
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO UserAuditLog (IdUser, PeopleId, PeoplePassword, Operation)
                SELECT 
                    d.IdUser, 
                    d.PeopleId, 
                    d.PeoplePassword, 
                    'DELETE'
                FROM 
                    deleted d;
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AuditLogOnDelete_User");
        }
    }
}
