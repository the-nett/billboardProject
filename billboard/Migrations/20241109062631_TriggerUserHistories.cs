using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    public partial class TriggerUserHistories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE TRIGGER [dbo].[TgUsers] 
                ON [dbo].[Users]
                AFTER DELETE, UPDATE
                AS 
                BEGIN
                    SET NOCOUNT ON;

                    INSERT INTO [dbo].[UserHistories]
                           ([IdUser]
                           ,[PeopleId]
                           ,[PeoplePassword]
                           ,[PeopleSalt]
                           ,[Modified]
                           ,[IdUserType]
                           ,[StateDelete])
                    SELECT 
                           D.IdUser,
                           D.PeopleId,
                           D.PeoplePassword,
                           D.PeopleSalt,
                           GETDATE(),       -- Fecha y hora de modificación
                           D.IdUserType,
                           D.StateDelete
                    FROM deleted D;
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS [dbo].[TgUsers]");
        }
    }
}
