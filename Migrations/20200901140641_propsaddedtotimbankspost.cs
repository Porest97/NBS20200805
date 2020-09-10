using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class propsaddedtotimbankspost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TimBanksPost",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TBPStatusId",
                table: "TimBanksPost",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WLNumber",
                table: "TimBanksPost",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBPStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TBPStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimBanksPost_TBPStatusId",
                table: "TimBanksPost",
                column: "TBPStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimBanksPost_TBPStatus_TBPStatusId",
                table: "TimBanksPost",
                column: "TBPStatusId",
                principalTable: "TBPStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimBanksPost_TBPStatus_TBPStatusId",
                table: "TimBanksPost");

            migrationBuilder.DropTable(
                name: "TBPStatus");

            migrationBuilder.DropIndex(
                name: "IX_TimBanksPost_TBPStatusId",
                table: "TimBanksPost");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TimBanksPost");

            migrationBuilder.DropColumn(
                name: "TBPStatusId",
                table: "TimBanksPost");

            migrationBuilder.DropColumn(
                name: "WLNumber",
                table: "TimBanksPost");
        }
    }
}
