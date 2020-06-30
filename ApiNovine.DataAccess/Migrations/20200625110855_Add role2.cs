using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiNovine.DataAccess.Migrations
{
    public partial class Addrole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Roles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "Admin",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
