using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace billboard.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLevelTimer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelTime",
                table: "Games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "LevelTime",
                table: "Games",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
