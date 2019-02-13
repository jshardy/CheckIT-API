using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class Test_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_CustAddressID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Invoices_CustInvoiceID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_LineItems_InventoryLineID",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_LineItems_InvoiceLineID",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryAlertID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryLineID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustAddressID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustInvoiceID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IncomingInv",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InventoryLineID",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CustAddressID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustInvoiceID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IventoryId",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "InvoiceLineID",
                table: "Invoices",
                newName: "InvoiceCustID");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_InvoiceLineID",
                table: "Invoices",
                newName: "IX_Invoices_InvoiceCustID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Customers",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UserPermissionsId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineInventoryID",
                table: "LineItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LineInvoiceID",
                table: "LineItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressCustID",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SetUserPermissions = table.Column<bool>(nullable: false),
                    ViewUserPermissions = table.Column<bool>(nullable: false),
                    AddIventory = table.Column<bool>(nullable: false),
                    ArchiveIventory = table.Column<bool>(nullable: false),
                    UpdateInventory = table.Column<bool>(nullable: false),
                    AddInvoice = table.Column<bool>(nullable: false),
                    ArchiveInvoice = table.Column<bool>(nullable: false),
                    ViewInvoices = table.Column<bool>(nullable: false),
                    AddLocation = table.Column<bool>(nullable: false),
                    DeleteLocation = table.Column<bool>(nullable: false),
                    AddAlert = table.Column<bool>(nullable: false),
                    DeleteAlert = table.Column<bool>(nullable: false),
                    UpdateAlert = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserPermissionsId",
                table: "Users",
                column: "UserPermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_LineInventoryID",
                table: "LineItems",
                column: "LineInventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_LineInvoiceID",
                table: "LineItems",
                column: "LineInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryAlertID",
                table: "Inventories",
                column: "InventoryAlertID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressCustID",
                table: "Addresses",
                column: "AddressCustID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_AddressCustID",
                table: "Addresses",
                column: "AddressCustID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_InvoiceCustID",
                table: "Invoices",
                column: "InvoiceCustID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Inventories_LineInventoryID",
                table: "LineItems",
                column: "LineInventoryID",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Invoices_LineInvoiceID",
                table: "LineItems",
                column: "LineInvoiceID",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Permissions_UserPermissionsId",
                table: "Users",
                column: "UserPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_AddressCustID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_InvoiceCustID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Inventories_LineInventoryID",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Invoices_LineInvoiceID",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Permissions_UserPermissionsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserPermissionsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_LineInventoryID",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_LineInvoiceID",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryAlertID",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressCustID",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserPermissionsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LineInventoryID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "LineInvoiceID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "AddressCustID",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "InvoiceCustID",
                table: "Invoices",
                newName: "InvoiceLineID");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_InvoiceCustID",
                table: "Invoices",
                newName: "IX_Invoices_InvoiceLineID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "ID");

            migrationBuilder.AddColumn<bool>(
                name: "IncomingInv",
                table: "Invoices",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "InventoryLineID",
                table: "Inventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustAddressID",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustInvoiceID",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IventoryId",
                table: "Alerts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryAlertID",
                table: "Inventories",
                column: "InventoryAlertID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryLineID",
                table: "Inventories",
                column: "InventoryLineID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustAddressID",
                table: "Customers",
                column: "CustAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustInvoiceID",
                table: "Customers",
                column: "CustInvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_CustAddressID",
                table: "Customers",
                column: "CustAddressID",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Invoices_CustInvoiceID",
                table: "Customers",
                column: "CustInvoiceID",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_LineItems_InventoryLineID",
                table: "Inventories",
                column: "InventoryLineID",
                principalTable: "LineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_LineItems_InvoiceLineID",
                table: "Invoices",
                column: "InvoiceLineID",
                principalTable: "LineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
