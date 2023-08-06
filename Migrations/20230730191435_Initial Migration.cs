using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web1001_TodoApp.Migrations
{
    // Migration class for creating the initial database schema
    public partial class InitialMigration : Migration
    {
        // Up method contains the operations to create the schema
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos", // Table name
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true), // Auto-increment primary key
                    Title = table.Column<string>(type: "TEXT", nullable: false), // Todo title
                    Details = table.Column<string>(type: "TEXT", nullable: false), // Todo details
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false), // Completion status
                    CompleteDate = table.Column<DateTime>(type: "TEXT", nullable: true) // Completion date
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id); // Primary key constraint
                });
        }

        // Down method contains the operations to reverse the schema creation
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos"); // Drop the "Todos" table
        }
    }
}
