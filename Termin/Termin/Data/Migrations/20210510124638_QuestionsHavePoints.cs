using Microsoft.EntityFrameworkCore.Migrations;

namespace Termin.Data.Migrations
{
    public partial class QuestionsHavePoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "StudentTestAsnwers");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Questions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "StudentTestAsnwers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
