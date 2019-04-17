using Microsoft.EntityFrameworkCore.Migrations;

namespace HW6MovieSharing.Migrations
{
    public partial class Movie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sharable",
                table: "Movie",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sharable",
                table: "Movie");
        }
    }
}
