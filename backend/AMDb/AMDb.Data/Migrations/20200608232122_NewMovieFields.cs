using Microsoft.EntityFrameworkCore.Migrations;

namespace AMDb.Data.Migrations
{
    public partial class NewMovieFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Storyline",
                table: "Movies",
                maxLength: 600,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SummaryText",
                table: "Movies",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrailerUrl",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Storyline",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "SummaryText",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TrailerUrl",
                table: "Movies");
        }
    }
}
