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
            migrationBuilder.DropForeignKey(
                name: "FK_DialogueHistories_StudentDialoguesStatistic_StudentDialogu~",
                table: "DialogueHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentDialoguesStatistic_Students_StudentId",
                table: "StudentDialoguesStatistic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDialoguesStatistic",
                table: "StudentDialoguesStatistic");

            migrationBuilder.RenameTable(
                name: "StudentDialoguesStatistic",
                newName: "StudentDialoguesStatistics");

            migrationBuilder.RenameIndex(
                name: "IX_StudentDialoguesStatistic_StudentId",
                table: "StudentDialoguesStatistics",
                newName: "IX_StudentDialoguesStatistics_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDialoguesStatistics",
                table: "StudentDialoguesStatistics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DialogueHistories_StudentDialoguesStatistics_StudentDialog~",
                table: "DialogueHistories",
                column: "StudentDialogueStatisticId",
                principalTable: "StudentDialoguesStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDialoguesStatistics_Students_StudentId",
                table: "StudentDialoguesStatistics",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DialogueHistories_StudentDialoguesStatistics_StudentDialog~",
                table: "DialogueHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentDialoguesStatistics_Students_StudentId",
                table: "StudentDialoguesStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDialoguesStatistics",
                table: "StudentDialoguesStatistics");

            migrationBuilder.RenameTable(
                name: "StudentDialoguesStatistics",
                newName: "StudentDialoguesStatistic");

            migrationBuilder.RenameIndex(
                name: "IX_StudentDialoguesStatistics_StudentId",
                table: "StudentDialoguesStatistic",
                newName: "IX_StudentDialoguesStatistic_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDialoguesStatistic",
                table: "StudentDialoguesStatistic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DialogueHistories_StudentDialoguesStatistic_StudentDialogu~",
                table: "DialogueHistories",
                column: "StudentDialogueStatisticId",
                principalTable: "StudentDialoguesStatistic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDialoguesStatistic_Students_StudentId",
                table: "StudentDialoguesStatistic",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
