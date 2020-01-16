using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnProject.Data.Migrations
{
    public partial class AddLogCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Errors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Errors");
        }
    }
}
