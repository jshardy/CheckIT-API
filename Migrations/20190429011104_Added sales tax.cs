using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class Addedsalestax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Invoices");
        }
    }
}
