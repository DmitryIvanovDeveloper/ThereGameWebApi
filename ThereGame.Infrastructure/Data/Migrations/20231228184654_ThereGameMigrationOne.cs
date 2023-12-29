using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThereGameMigrationOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Answers");

            migrationBuilder.AddColumn<string[]>(
                name: "Texts",
                table: "Answers",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Texts",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Answers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
