using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class Changedpermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserPermissionsClass_UserPermissionsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserPermissionsClass");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserPermissionsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserPermissionsId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PermissionsUserId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Users_PermissionsUserId",
                        column: x => x.PermissionsUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionsUserId",
                table: "Permissions",
                column: "PermissionsUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.AddColumn<int>(
                name: "UserPermissionsId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserPermissionsClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddAlert = table.Column<bool>(nullable: false),
                    AddCustomer = table.Column<bool>(nullable: false),
                    AddInvoice = table.Column<bool>(nullable: false),
                    AddIventory = table.Column<bool>(nullable: false),
                    AddLocation = table.Column<bool>(nullable: false),
                    ArchiveInvoice = table.Column<bool>(nullable: false),
                    ArchiveIventory = table.Column<bool>(nullable: false),
                    DeleteAlert = table.Column<bool>(nullable: false),
                    DeleteCustomer = table.Column<bool>(nullable: false),
                    DeleteLocation = table.Column<bool>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    SetUserPermissions = table.Column<bool>(nullable: false),
                    UpdateAlert = table.Column<bool>(nullable: false),
                    UpdateCustomer = table.Column<bool>(nullable: false),
                    UpdateInventory = table.Column<bool>(nullable: false),
                    UpdateInvoice = table.Column<bool>(nullable: false),
                    ViewAlert = table.Column<bool>(nullable: false),
                    ViewCustomer = table.Column<bool>(nullable: false),
                    ViewInventory = table.Column<bool>(nullable: false),
                    ViewInvoice = table.Column<bool>(nullable: false),
                    ViewLocation = table.Column<bool>(nullable: false),
                    ViewUserPermissions = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionsClass", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserPermissionsId",
                table: "Users",
                column: "UserPermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserPermissionsClass_UserPermissionsId",
                table: "Users",
                column: "UserPermissionsId",
                principalTable: "UserPermissionsClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
