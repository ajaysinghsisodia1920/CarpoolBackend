using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carpool.DataStorage.Migrations
{
    public partial class II : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RideOfferName",
                table: "BookedRides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RideOfferName",
                table: "BookedRides");
        }
    }
}
