using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketService.Migrations
{
    public partial class UpForSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUpForSale",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpForSale",
                table: "Items");
        }
    }
}
