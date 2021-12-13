using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketService.Migrations
{
    public partial class ItemsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Markets_MarketId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "MarketId",
                table: "Items",
                newName: "marketId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_MarketId",
                table: "Items",
                newName: "IX_Items_marketId");

            migrationBuilder.AlterColumn<int>(
                name: "marketId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Markets_marketId",
                table: "Items",
                column: "marketId",
                principalTable: "Markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Markets_marketId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "marketId",
                table: "Items",
                newName: "MarketId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_marketId",
                table: "Items",
                newName: "IX_Items_MarketId");

            migrationBuilder.AlterColumn<int>(
                name: "MarketId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Markets_MarketId",
                table: "Items",
                column: "MarketId",
                principalTable: "Markets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
