using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InLifeMigrationG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslateWordsGameStatistics_StudentsVocabularyBlocks_Stude~",
                table: "TranslateWordsGameStatistics");

            migrationBuilder.DropIndex(
                name: "IX_TranslateWordsGameStatistics_StudentVocabularyBlockModelId",
                table: "TranslateWordsGameStatistics");

            migrationBuilder.DropColumn(
                name: "StudentVocabularyBlockModelId",
                table: "TranslateWordsGameStatistics");

            migrationBuilder.CreateIndex(
                name: "IX_TranslateWordsGameStatistics_VocabularyBlockId",
                table: "TranslateWordsGameStatistics",
                column: "VocabularyBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslateWordsGameStatistics_StudentsVocabularyBlocks_Vocab~",
                table: "TranslateWordsGameStatistics",
                column: "VocabularyBlockId",
                principalTable: "StudentsVocabularyBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslateWordsGameStatistics_StudentsVocabularyBlocks_Vocab~",
                table: "TranslateWordsGameStatistics");

            migrationBuilder.DropIndex(
                name: "IX_TranslateWordsGameStatistics_VocabularyBlockId",
                table: "TranslateWordsGameStatistics");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentVocabularyBlockModelId",
                table: "TranslateWordsGameStatistics",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranslateWordsGameStatistics_StudentVocabularyBlockModelId",
                table: "TranslateWordsGameStatistics",
                column: "StudentVocabularyBlockModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslateWordsGameStatistics_StudentsVocabularyBlocks_Stude~",
                table: "TranslateWordsGameStatistics",
                column: "StudentVocabularyBlockModelId",
                principalTable: "StudentsVocabularyBlocks",
                principalColumn: "Id");
        }
    }
}
