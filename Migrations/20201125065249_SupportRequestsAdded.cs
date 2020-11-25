using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class SupportRequestsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestPrios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestPrioName = table.Column<string>(nullable: true),
                    RequestPrioDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPrios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCompany = table.Column<string>(nullable: true),
                    ClientContact = table.Column<string>(nullable: true),
                    ClientEmail = table.Column<string>(nullable: true),
                    ClientPhoneNumber = table.Column<string>(nullable: true),
                    ClientSite = table.Column<string>(nullable: true),
                    SiteNumber = table.Column<string>(nullable: true),
                    SiteName = table.Column<string>(nullable: true),
                    SiteArea = table.Column<string>(nullable: true),
                    RequestTypeId = table.Column<int>(nullable: true),
                    RequestStatusId = table.Column<int>(nullable: true),
                    RequestPrioId = table.Column<int>(nullable: true),
                    DateTimePosted = table.Column<DateTime>(nullable: true),
                    RequestDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportRequests_RequestPrios_RequestPrioId",
                        column: x => x.RequestPrioId,
                        principalTable: "RequestPrios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportRequests_RequestStatuses_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RequestStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportRequests_RequestTypes_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_RequestPrioId",
                table: "SupportRequests",
                column: "RequestPrioId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_RequestStatusId",
                table: "SupportRequests",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_RequestTypeId",
                table: "SupportRequests",
                column: "RequestTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportRequests");

            migrationBuilder.DropTable(
                name: "RequestPrios");

            migrationBuilder.DropTable(
                name: "RequestStatuses");

            migrationBuilder.DropTable(
                name: "RequestTypes");
        }
    }
}
