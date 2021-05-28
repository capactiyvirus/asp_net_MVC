using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp_MVC.Data.Migrations
{
    public partial class addeduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user",
                table: "Joke",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user",
                table: "Joke");
        }
    }
}
