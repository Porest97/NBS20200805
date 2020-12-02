using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class StatusAddedToOutlays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Outlays",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Outlays_StatusId",
                table: "Outlays",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Outlays_Statuses_StatusId",
                table: "Outlays",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outlays_Statuses_StatusId",
                table: "Outlays");

            migrationBuilder.DropIndex(
                name: "IX_Outlays_StatusId",
                table: "Outlays");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Outlays");
        }
    }
}
