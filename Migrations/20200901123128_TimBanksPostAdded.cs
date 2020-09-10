using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class TimBanksPostAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimBanksPost",
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
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimBanksPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimBanksPost_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimBanksPost_PersonId",
                table: "TimBanksPost",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimBanksPost");
        }
    }
}
