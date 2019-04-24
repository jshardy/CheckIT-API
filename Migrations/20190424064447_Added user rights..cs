using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class Addeduserrights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ViewInvoices",
                table: "Permissions",
                newName: "ViewLocation");

            migrationBuilder.AddColumn<bool>(
                name: "AddCustomer",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteCustomer",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Permissions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "UpdateCustomer",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UpdateInvoice",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ViewAlert",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ViewCustomer",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ViewInventory",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ViewInvoice",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AlertTriggered",
                table: "Alerts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddCustomer",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DeleteCustomer",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "UpdateCustomer",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "UpdateInvoice",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ViewAlert",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ViewCustomer",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ViewInventory",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ViewInvoice",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "AlertTriggered",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "ViewLocation",
                table: "Permissions",
                newName: "ViewInvoices");
        }
    }
}
