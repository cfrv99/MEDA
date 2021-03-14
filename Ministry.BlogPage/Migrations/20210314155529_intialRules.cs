using Microsoft.EntityFrameworkCore.Migrations;

namespace Ministry.BlogPage.Migrations
{
    public partial class intialRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "RuleFiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "RuleFiles");
        }
    }
}
