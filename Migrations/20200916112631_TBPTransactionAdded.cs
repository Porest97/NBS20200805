using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class TBPTransactionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    SallaryAccountId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TransactionAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPTransaction_SallaryAccount_SallaryAccountId",
                        column: x => x.SallaryAccountId,
                        principalTable: "SallaryAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPTransaction_SallaryAccountId",
                table: "TBPTransaction",
                column: "SallaryAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPTransaction");
        }
    }
}
