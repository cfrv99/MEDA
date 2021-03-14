using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ministry.BlogPage.Migrations
{
    public partial class intialAnnoucement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Announcements");
        }
    }
}
