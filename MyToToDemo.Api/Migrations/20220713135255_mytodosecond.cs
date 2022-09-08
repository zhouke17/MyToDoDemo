using Microsoft.EntityFrameworkCore.Migrations;

namespace MyToToDemo.Api.Migrations
{
    public partial class mytodosecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "content",
                table: "ToDos",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ToDos",
                newName: "content");
        }
    }
}
