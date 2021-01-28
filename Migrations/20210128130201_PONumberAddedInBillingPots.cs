using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class PONumberAddedInBillingPots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PONumber",
                table: "BillingPost",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PONumber",
                table: "BillingPost");
        }
    }
}
