using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class Fixed_Inventory_Spelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncomingInv",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "IventoryId",
                table: "Alerts",
                newName: "AlertInvId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlertInvId",
                table: "Alerts",
                newName: "IventoryId");

            migrationBuilder.AddColumn<bool>(
                name: "IncomingInv",
                table: "Invoices",
                nullable: false,
                defaultValue: false);
        }
    }
}
