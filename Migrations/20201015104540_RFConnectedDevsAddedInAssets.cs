using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class RFConnectedDevsAddedInAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RFConnectedDevs",
                table: "Asset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RFConnectedDevs",
                table: "Asset");
        }
    }
}
