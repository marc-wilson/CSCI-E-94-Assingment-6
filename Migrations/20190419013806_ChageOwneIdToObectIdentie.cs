using Microsoft.EntityFrameworkCore.Migrations;

namespace HW6MovieSharing.Migrations
{
    public partial class ChageOwneIdToObectIdentie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "OwnerObjectIdentifier",
                table: "Movie",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerObjectIdentifier",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Movie",
                nullable: false,
                defaultValue: 0);
        }
    }
}
