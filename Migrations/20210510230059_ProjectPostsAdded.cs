using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class ProjectPostsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectPostStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectPostStatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPostStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimePosted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeChanged = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectPostDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimePlaned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeDone = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HourPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeEstimate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCostEstimate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MtrCostActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LabourCostActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCostActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectPostStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPost_ProjectPostStatus_ProjectPostStatusId",
                        column: x => x.ProjectPostStatusId,
                        principalTable: "ProjectPostStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPost_ProjectPostStatusId",
                table: "ProjectPost",
                column: "ProjectPostStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPost");

            migrationBuilder.DropTable(
                name: "ProjectPostStatus");
        }
    }
}
