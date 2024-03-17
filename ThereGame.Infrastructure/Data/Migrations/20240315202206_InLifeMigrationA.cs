using System;
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
            migrationBuilder.DropColumn(
                name: "Order",
                table: "StudentsVocabularyBlocks");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StudentsVocabularyBlocks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StudentsVocabularyBlocks");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "StudentsVocabularyBlocks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
