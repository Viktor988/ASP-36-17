using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiNovine.DataAccess.Migrations
{
    public partial class addtagpostdateentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TagPosts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TagPosts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TagPosts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TagPosts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "TagPosts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TagPosts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TagPosts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TagPosts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TagPosts");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "TagPosts");
        }
    }
}
