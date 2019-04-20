using Microsoft.EntityFrameworkCore.Migrations;

namespace HW6MovieSharing.Migrations
{
    public partial class AddedPropsToBarrowRqust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MoveTitle",
                table: "BarrowRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieOwner",
                table: "BarrowRequest",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BarrowRequest",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoveTitle",
                table: "BarrowRequest");

            migrationBuilder.DropColumn(
                name: "MovieOwner",
                table: "BarrowRequest");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BarrowRequest");
        }
    }
}
