using Microsoft.EntityFrameworkCore.Migrations;

namespace Termin.Data.Migrations
{
    public partial class changeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Daration",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Tests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "Daration",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
