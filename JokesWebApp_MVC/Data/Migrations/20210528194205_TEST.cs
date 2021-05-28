using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp_MVC.Data.Migrations
{
    public partial class TEST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user",
                table: "Joke",
                newName: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Joke",
                newName: "user");
        }
    }
}
