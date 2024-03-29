using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBooks.Migrations
{
    public partial class ManyToManyAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Authors",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Authors",
                newName: "Name");
        }
    }
}
