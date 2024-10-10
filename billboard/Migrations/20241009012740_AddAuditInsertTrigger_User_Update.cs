using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditInsertTrigger_User_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE TRIGGER trg_AuditLogOnUpdate_User
            ON dbo.[Users]
            AFTER UPDATE
            AS
            BEGIN
                SET NOCOUNT ON;

                INSERT INTO UserAuditLog (IdUser, PeopleId, PeoplePassword, Operation)
                SELECT 
                    i.IdUser, 
                    i.PeopleId, 
                    i.PeoplePassword, 
                    'UPDATE'
                FROM 
                    inserted i;
            END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_AuditLogOnUpdate_User");
        }
    }
}
