using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class SallariesControllerImplemented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SallaryAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    AccountName = table.Column<string>(nullable: true),
                    AccountBalance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SallaryAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SallaryAccount_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SallaryAccountId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TransactionAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_SallaryAccount_SallaryAccountId",
                        column: x => x.SallaryAccountId,
                        principalTable: "SallaryAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SallaryAccount_PersonId",
                table: "SallaryAccount",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_SallaryAccountId",
                table: "Transaction",
                column: "SallaryAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "SallaryAccount");
        }
    }
}
