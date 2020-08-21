using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class PansAltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Site_SiteIdId",
                table: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Plan_SiteIdId",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "SiteIdId",
                table: "Plan");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_SiteId",
                table: "Plan",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Site_SiteId",
                table: "Plan",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Site_SiteId",
                table: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Plan_SiteId",
                table: "Plan");

            migrationBuilder.AddColumn<int>(
                name: "SiteIdId",
                table: "Plan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plan_SiteIdId",
                table: "Plan",
                column: "SiteIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Site_SiteIdId",
                table: "Plan",
                column: "SiteIdId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
