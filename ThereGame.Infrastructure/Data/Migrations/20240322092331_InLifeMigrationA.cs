using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InLifeMigrationA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizlGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    HiddenWordId = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizlGame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Word = table.Column<string>(type: "text", nullable: false),
                    Pictures = table.Column<string[]>(type: "text[]", nullable: false),
                    SpeechParts = table.Column<int[]>(type: "integer[]", nullable: false),
                    Forms = table.Column<string>(type: "text", nullable: false),
                    QuizlGamesId = table.Column<List<Guid>>(type: "uuid[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WordTranslates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Translates = table.Column<List<string>>(type: "text[]", nullable: false),
                    WordId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordTranslates_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDialoguesStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DialogueId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDialoguesStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDialoguesStatistics_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsVocabularyBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "DialogueHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    PhraseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Phrase = table.Column<string>(type: "text", nullable: false),
                    Answers = table.Column<List<string>>(type: "text[]", nullable: false),
                    StudentDialogueStatisticId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogueHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DialogueHistories_StudentDialoguesStatistics_StudentDialogu~",
                        column: x => x.StudentDialogueStatisticId,
                        principalTable: "StudentDialoguesStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizlGameStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizlGameId = table.Column<Guid>(type: "uuid", nullable: false),
                    Answers = table.Column<List<string>>(type: "text[]", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VocabulryBlockId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentVocabularyBlockModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizlGameStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizlGameStatistics_StudentsVocabularyBlocks_StudentVocabul~",
                        column: x => x.StudentVocabularyBlockModelId,
                        principalTable: "StudentsVocabularyBlocks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Texts = table.Column<string[]>(type: "text[]", nullable: false),
                    Tenseses = table.Column<string[]>(type: "text[]", nullable: false),
                    WordsToUse = table.Column<string>(type: "text", nullable: false),
                    ParentPhraseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MistakeExplanations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Word = table.Column<string>(type: "text", nullable: false),
                    Explanation = table.Column<string>(type: "text", nullable: false),
                    AnswerParentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MistakeExplanations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MistakeExplanations_Answers_AnswerParentId",
                        column: x => x.AnswerParentId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phrases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: false),
                    Tenseses = table.Column<string[]>(type: "text[]", nullable: false),
                    ParentAnswerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phrases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phrases_Answers_ParentAnswerId",
                        column: x => x.ParentAnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    AnswerParentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translates_Answers_AnswerParentId",
                        column: x => x.AnswerParentId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudioSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenerationSettings = table.Column<string>(type: "text", nullable: false),
                    AudioData = table.Column<string>(type: "text", nullable: false),
                    Revision = table.Column<int>(type: "integer", nullable: false),
                    ParentPhraseId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Dialogues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    VoiceSettings = table.Column<string>(type: "text", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhraseId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<List<Guid>>(type: "uuid[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialogues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dialogues_Phrases_PhraseId",
                        column: x => x.PhraseId,
                        principalTable: "Phrases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dialogues_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ParentPhraseId",
                table: "Answers",
                column: "ParentPhraseId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioSettings_ParentPhraseId",
                table: "AudioSettings",
                column: "ParentPhraseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DialogueHistories_StudentDialogueStatisticId",
                table: "DialogueHistories",
                column: "StudentDialogueStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogues_PhraseId",
                table: "Dialogues",
                column: "PhraseId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogues_TeacherId",
                table: "Dialogues",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_MistakeExplanations_AnswerParentId",
                table: "MistakeExplanations",
                column: "AnswerParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Phrases_ParentAnswerId",
                table: "Phrases",
                column: "ParentAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizlGameStatistics_StudentVocabularyBlockModelId",
                table: "QuizlGameStatistics",
                column: "StudentVocabularyBlockModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDialoguesStatistics_StudentId",
                table: "StudentDialoguesStatistics",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsVocabularyBlocks_StudentId",
                table: "StudentsVocabularyBlocks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Translates_AnswerParentId",
                table: "Translates",
                column: "AnswerParentId");

            migrationBuilder.CreateIndex(
                name: "IX_WordTranslates_WordId",
                table: "WordTranslates",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Phrases_ParentPhraseId",
                table: "Answers",
                column: "ParentPhraseId",
                principalTable: "Phrases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Phrases_ParentPhraseId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "AudioSettings");

            migrationBuilder.DropTable(
                name: "DialogueHistories");

            migrationBuilder.DropTable(
                name: "Dialogues");

            migrationBuilder.DropTable(
                name: "MistakeExplanations");

            migrationBuilder.DropTable(
                name: "QuizlGame");

            migrationBuilder.DropTable(
                name: "QuizlGameStatistics");

            migrationBuilder.DropTable(
                name: "Translates");

            migrationBuilder.DropTable(
                name: "WordTranslates");

            migrationBuilder.DropTable(
                name: "StudentDialoguesStatistics");

            migrationBuilder.DropTable(
                name: "StudentsVocabularyBlocks");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Phrases");

            migrationBuilder.DropTable(
                name: "Answers");
        }
    }
}
