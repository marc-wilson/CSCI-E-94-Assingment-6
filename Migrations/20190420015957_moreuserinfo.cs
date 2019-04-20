using Microsoft.EntityFrameworkCore.Migrations;

namespace HW6MovieSharing.Migrations
{
    public partial class moreuserinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestedBy",
                table: "BarrowRequest",
                newName: "RequestedByObjectIdentifier");

            migrationBuilder.AddColumn<string>(
                name: "RequestedByEmailAddress",
                table: "BarrowRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestedByFirstName",
                table: "BarrowRequest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestedByLastName",
                table: "BarrowRequest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedByEmailAddress",
                table: "BarrowRequest");

            migrationBuilder.DropColumn(
                name: "RequestedByFirstName",
                table: "BarrowRequest");

            migrationBuilder.DropColumn(
                name: "RequestedByLastName",
                table: "BarrowRequest");

            migrationBuilder.RenameColumn(
                name: "RequestedByObjectIdentifier",
                table: "BarrowRequest",
                newName: "RequestedBy");
        }
    }
}
