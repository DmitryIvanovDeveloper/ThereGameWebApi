using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThereGameMigrationC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioData",
                table: "Phrases");

            migrationBuilder.DropColumn(
                name: "AudioGenerationSettings",
                table: "Phrases");

            migrationBuilder.CreateTable(
                name: "AudioSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenerationSettings = table.Column<string>(type: "text", nullable: false),
                    AudioData = table.Column<string>(type: "text", nullable: false),
                    Revision = table.Column<int>(type: "integer", nullable: false),
                    ParentPhraseId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioSettings_Phrases_ParentPhraseId",
                        column: x => x.ParentPhraseId,
                        principalTable: "Phrases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioSettings_ParentPhraseId",
                table: "AudioSettings",
                column: "ParentPhraseId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioSettings");

            migrationBuilder.AddColumn<string>(
                name: "AudioData",
                table: "Phrases",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AudioGenerationSettings",
                table: "Phrases",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
