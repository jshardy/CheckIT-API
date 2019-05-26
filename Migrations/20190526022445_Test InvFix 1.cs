using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class TestInvFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Alerts_InventoryAlertID",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Locations_InventoryLocationID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryAlertID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryLocationID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InventoryAlertID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InventoryLocationID",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationsId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlertInvId",
                table: "Alerts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_LocationsId",
                table: "Inventories",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_AlertInvId",
                table: "Alerts",
                column: "AlertInvId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Inventories_AlertInvId",
                table: "Alerts",
                column: "AlertInvId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Locations_LocationsId",
                table: "Inventories",
                column: "LocationsId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Inventories_AlertInvId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Locations_LocationsId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_LocationsId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_AlertInvId",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LocationsId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "AlertInvId",
                table: "Alerts");

            migrationBuilder.AddColumn<int>(
                name: "InventoryAlertID",
                table: "Inventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryLocationID",
                table: "Inventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryAlertID",
                table: "Inventories",
                column: "InventoryAlertID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryLocationID",
                table: "Inventories",
                column: "InventoryLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Alerts_InventoryAlertID",
                table: "Inventories",
                column: "InventoryAlertID",
                principalTable: "Alerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Locations_InventoryLocationID",
                table: "Inventories",
                column: "InventoryLocationID",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
