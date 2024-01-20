using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThereGameMigrationI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVoiceSelected",
                table: "Dialogues");

            migrationBuilder.AddColumn<string>(
                name: "VoiceSettings",
                table: "Dialogues",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoiceSettings",
                table: "Dialogues");

            migrationBuilder.AddColumn<bool>(
                name: "IsVoiceSelected",
                table: "Dialogues",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
