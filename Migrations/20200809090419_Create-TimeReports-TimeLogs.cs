using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class CreateTimeReportsTimeLogs : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeLogStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeLogStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLogStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeReportName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateTimeCreated = table.Column<DateTime>(nullable: true),
                    DateTimeFrom = table.Column<DateTime>(nullable: true),
                    DateTimeTo = table.Column<DateTime>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeReport_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeReport_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeReportStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeReportStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReportStatus", x => x.Id);
                });            

            migrationBuilder.CreateTable(
                name: "TimeLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    IncidentId = table.Column<int>(nullable: true),
                    DateTimeStarted = table.Column<DateTime>(nullable: true),
                    DateTimeEnded = table.Column<DateTime>(nullable: true),
                    LogNotes = table.Column<string>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    PriceHour = table.Column<decimal>(nullable: false),
                    MtrCost = table.Column<decimal>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    WLogId = table.Column<int>(nullable: true),
                    TimeLogStatusId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    IsSelected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeLog_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeLog_Incident_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeLog_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeLog_TimeLogStatus_TimeLogStatusId",
                        column: x => x.TimeLogStatusId,
                        principalTable: "TimeLogStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeLog_WLog_WLogId",
                        column: x => x.WLogId,
                        principalTable: "WLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_ApplicationUserId",
                table: "TimeLog",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_IncidentId",
                table: "TimeLog",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_PersonId",
                table: "TimeLog",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_TimeLogStatusId",
                table: "TimeLog",
                column: "TimeLogStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_WLogId",
                table: "TimeLog",
                column: "WLogId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReport_ApplicationUserId",
                table: "TimeReport",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReport_PersonId",
                table: "TimeReport",
                column: "PersonId");
        }     
        



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeLog");

            migrationBuilder.DropTable(
                name: "TimeReport");

            migrationBuilder.DropTable(
                name: "TimeReportStatus");

            migrationBuilder.DropTable(
                name: "TimeLogStatus");
        }
    }
}
