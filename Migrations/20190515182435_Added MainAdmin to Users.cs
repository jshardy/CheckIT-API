using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckIT.API.Migrations
{
    public partial class AddedMainAdmintoUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MainAdmin",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainAdmin",
                table: "Users");
        }
    }
}
