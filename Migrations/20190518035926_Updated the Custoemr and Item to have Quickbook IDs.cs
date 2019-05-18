using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class UpdatedtheCustoemrandItemtohaveQuickbookIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QB_Id",
                table: "Inventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QB_Id",
                table: "Customers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QB_Id",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "QB_Id",
                table: "Customers");
        }
    }
}
