using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class ShiftDescriptionAddedToProjectPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShiftDescription",
                table: "ProjectPost",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftDescription",
                table: "ProjectPost");
        }
    }
}
