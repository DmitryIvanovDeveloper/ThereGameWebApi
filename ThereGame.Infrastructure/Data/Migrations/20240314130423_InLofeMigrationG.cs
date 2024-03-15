using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InLofeMigrationG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VocabularyIdList",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "StudentsVocabularyBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    WordsId = table.Column<List<Guid>>(type: "uuid[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsVocabularyBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsVocabularyBlocks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsVocabularyBlocks_StudentId",
                table: "StudentsVocabularyBlocks",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsVocabularyBlocks");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "VocabularyIdList",
                table: "Students",
                type: "uuid[]",
                nullable: false);
        }
    }
}
