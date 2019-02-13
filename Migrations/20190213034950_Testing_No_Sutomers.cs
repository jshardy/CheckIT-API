using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class Testing_No_Sutomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_CustAddressID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustAddressID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IncomingInv",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustAddressID",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "IventoryId",
                table: "Alerts",
                newName: "AlertInvId");

            migrationBuilder.AddColumn<int>(
                name: "UserPermissionsId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressofCustId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserPermissions = table.Column<bool>(nullable: false),
                    AddIventory = table.Column<bool>(nullable: false),
                    ArchiveIventory = table.Column<bool>(nullable: false),
                    AddInvoice = table.Column<bool>(nullable: false),
                    ArchiveInvoice = table.Column<bool>(nullable: false),
                    AddLocation = table.Column<bool>(nullable: false),
                    DeleteLocation = table.Column<bool>(nullable: false)
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
                name: "IX_Addresses_AddressofCustId",
                table: "Addresses",
                column: "AddressofCustId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerID",
                table: "Addresses",
                column: "CustomerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Addresses_AddressofCustId",
                table: "Addresses",
                column: "AddressofCustId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_CustomerID",
                table: "Addresses",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
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
                name: "FK_Addresses_Addresses_AddressofCustId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Permissions_UserPermissionsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserPermissionsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressofCustId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerID",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserPermissionsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressofCustId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "AlertInvId",
                table: "Alerts",
                newName: "IventoryId");

            migrationBuilder.AddColumn<bool>(
                name: "IncomingInv",
                table: "Invoices",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CustAddressID",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustAddressID",
                table: "Customers",
                column: "CustAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_CustAddressID",
                table: "Customers",
                column: "CustAddressID",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
