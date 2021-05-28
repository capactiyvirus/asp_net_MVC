using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesWebApp_MVC.Data.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "Joke");

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

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Joke",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
