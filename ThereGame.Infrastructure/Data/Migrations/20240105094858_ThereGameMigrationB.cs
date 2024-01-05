using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThereGameMigrationB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Teachers");
        }
    }
}
