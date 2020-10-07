using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class ImageUploadToIncidentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_IncidentId",
                table: "Images",
                column: "IncidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Incident_IncidentId",
                table: "Images",
                column: "IncidentId",
                principalTable: "Incident",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Incident_IncidentId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_IncidentId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "Images");
        }
    }
}
