using Microsoft.EntityFrameworkCore.Migrations;

namespace capstone_backend.Migrations
{
    public partial class addednotestitlecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Note",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Note");
        }
    }
}
