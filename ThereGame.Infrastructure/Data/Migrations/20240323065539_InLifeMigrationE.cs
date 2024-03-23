using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InLifeMigrationE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TranslateWordsGameStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TranslateWordsGameGameId = table.Column<Guid>(type: "uuid", nullable: false),
                    Answers = table.Column<List<string>>(type: "text[]", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VocabularyBlockId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentVocabularyBlockModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslateWordsGameStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslateWordsGameStatistics_StudentsVocabularyBlocks_Stude~",
                        column: x => x.StudentVocabularyBlockModelId,
                        principalTable: "StudentsVocabularyBlocks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranslateWordsGameStatistics_StudentVocabularyBlockModelId",
                table: "TranslateWordsGameStatistics",
                column: "StudentVocabularyBlockModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslateWordsGameStatistics");
        }
    }
}
