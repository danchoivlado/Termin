using Microsoft.EntityFrameworkCore.Migrations;

namespace Termin.Data.Migrations
{
    public partial class demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Daration",
                table: "Tests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Daration",
                table: "Tests");
        }
    }
}
