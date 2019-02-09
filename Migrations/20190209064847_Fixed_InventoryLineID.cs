using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class Fixed_InventoryLineID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_LineItems_LineItemId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_LineItemId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "LineItemId",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryLineID",
                table: "Inventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryLineID",
                table: "Inventories",
                column: "InventoryLineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_LineItems_InventoryLineID",
                table: "Inventories",
                column: "InventoryLineID",
                principalTable: "LineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_LineItems_InventoryLineID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryLineID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InventoryLineID",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "LineItemId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_LineItemId",
                table: "Inventories",
                column: "LineItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_LineItems_LineItemId",
                table: "Inventories",
                column: "LineItemId",
                principalTable: "LineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
