using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class Relationship_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Invoices_InvoiceID",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Items_ItemID",
                table: "LineItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_InvoiceID",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_ItemID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "BusinessID",
                table: "Invoices",
                newName: "InvoiceLineID");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Customers",
                newName: "CustInvoiceID");

            migrationBuilder.AddColumn<int>(
                name: "CustAddressID",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompany",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IventoryId = table.Column<int>(nullable: false),
                    Threshold = table.Column<int>(nullable: false),
                    DateUnder = table.Column<DateTime>(nullable: false),
                    DateOrdered = table.Column<DateTime>(nullable: false),
                    AlertOn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UPC = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    InventoryLocationID = table.Column<int>(nullable: false),
                    InventoryAlertID = table.Column<int>(nullable: false),
                    LineItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Alerts_InventoryAlertID",
                        column: x => x.InventoryAlertID,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Locations_InventoryLocationID",
                        column: x => x.InventoryLocationID,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_LineItems_LineItemId",
                        column: x => x.LineItemId,
                        principalTable: "LineItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceLineID",
                table: "Invoices",
                column: "InvoiceLineID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustAddressID",
                table: "Customers",
                column: "CustAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustInvoiceID",
                table: "Customers",
                column: "CustInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryAlertID",
                table: "Inventories",
                column: "InventoryAlertID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryLocationID",
                table: "Inventories",
                column: "InventoryLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_LineItemId",
                table: "Inventories",
                column: "LineItemId");

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
                name: "FK_Invoices_LineItems_InvoiceLineID",
                table: "Invoices",
                column: "InvoiceLineID",
                principalTable: "LineItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_CustAddressID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Invoices_CustInvoiceID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_LineItems_InvoiceLineID",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_InvoiceLineID",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustAddressID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustInvoiceID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustAddressID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsCompany",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "InvoiceLineID",
                table: "Invoices",
                newName: "BusinessID");

            migrationBuilder.RenameColumn(
                name: "CustInvoiceID",
                table: "Customers",
                newName: "AddressID");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "LineItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "LineItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UPC = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_InvoiceID",
                table: "LineItems",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ItemID",
                table: "LineItems",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Invoices_InvoiceID",
                table: "LineItems",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Items_ItemID",
                table: "LineItems",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
