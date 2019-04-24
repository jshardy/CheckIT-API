using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class Addeduserpermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Permissions_UserPermissionsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.AddColumn<bool>(
                name: "AlertTriggered",
                table: "Alerts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserPermissionsClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<int>(nullable: false),
                    SetUserPermissions = table.Column<bool>(nullable: false),
                    ViewUserPermissions = table.Column<bool>(nullable: false),
                    AddIventory = table.Column<bool>(nullable: false),
                    ViewInventory = table.Column<bool>(nullable: false),
                    ArchiveIventory = table.Column<bool>(nullable: false),
                    UpdateInventory = table.Column<bool>(nullable: false),
                    AddInvoice = table.Column<bool>(nullable: false),
                    ArchiveInvoice = table.Column<bool>(nullable: false),
                    ViewInvoice = table.Column<bool>(nullable: false),
                    UpdateInvoice = table.Column<bool>(nullable: false),
                    AddLocation = table.Column<bool>(nullable: false),
                    DeleteLocation = table.Column<bool>(nullable: false),
                    ViewLocation = table.Column<bool>(nullable: false),
                    AddAlert = table.Column<bool>(nullable: false),
                    ViewAlert = table.Column<bool>(nullable: false),
                    DeleteAlert = table.Column<bool>(nullable: false),
                    UpdateAlert = table.Column<bool>(nullable: false),
                    AddCustomer = table.Column<bool>(nullable: false),
                    ViewCustomer = table.Column<bool>(nullable: false),
                    DeleteCustomer = table.Column<bool>(nullable: false),
                    UpdateCustomer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionsClass", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserPermissionsClass_UserPermissionsId",
                table: "Users",
                column: "UserPermissionsId",
                principalTable: "UserPermissionsClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserPermissionsClass_UserPermissionsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserPermissionsClass");

            migrationBuilder.DropColumn(
                name: "AlertTriggered",
                table: "Alerts");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddAlert = table.Column<bool>(nullable: false),
                    AddInvoice = table.Column<bool>(nullable: false),
                    AddIventory = table.Column<bool>(nullable: false),
                    AddLocation = table.Column<bool>(nullable: false),
                    ArchiveInvoice = table.Column<bool>(nullable: false),
                    ArchiveIventory = table.Column<bool>(nullable: false),
                    DeleteAlert = table.Column<bool>(nullable: false),
                    DeleteLocation = table.Column<bool>(nullable: false),
                    SetUserPermissions = table.Column<bool>(nullable: false),
                    UpdateAlert = table.Column<bool>(nullable: false),
                    UpdateInventory = table.Column<bool>(nullable: false),
                    ViewInvoices = table.Column<bool>(nullable: false),
                    ViewUserPermissions = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Permissions_UserPermissionsId",
                table: "Users",
                column: "UserPermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
