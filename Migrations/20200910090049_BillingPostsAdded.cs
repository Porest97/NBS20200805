using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class BillingPostsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BPStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BPStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillingPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(nullable: true),
                    Incident = table.Column<string>(nullable: true),
                    Started = table.Column<DateTime>(nullable: true),
                    Ended = table.Column<DateTime>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Outlay = table.Column<decimal>(nullable: false),
                    PersonId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    WLNumber = table.Column<string>(nullable: true),
                    BPStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingPost_BPStatus_BPStatusId",
                        column: x => x.BPStatusId,
                        principalTable: "BPStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillingPost_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingPost_BPStatusId",
                table: "BillingPost",
                column: "BPStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingPost_PersonId",
                table: "BillingPost",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingPost");

            migrationBuilder.DropTable(
                name: "BPStatus");
        }
    }
}
