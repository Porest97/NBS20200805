using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class OutlaysAddedToNBS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outlays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimePosted = table.Column<DateTime>(nullable: false),
                    DateTimeChanged = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    OutlayDateTime = table.Column<DateTime>(nullable: false),
                    OutlayDescription = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outlays_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Outlays_ApplicationUserId",
                table: "Outlays",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outlays");
        }
    }
}
