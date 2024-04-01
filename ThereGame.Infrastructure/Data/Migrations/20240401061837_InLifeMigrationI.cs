using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThereGame.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InLifeMigrationI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<Guid>>(
                name: "VocabularyWords",
                table: "Dialogues",
                type: "uuid[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VocabularyWords",
                table: "Dialogues");
        }
    }
}
