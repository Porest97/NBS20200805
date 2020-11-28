using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class DateTimePostedaddedInTestings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimePosted",
                table: "Testing",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimePosted",
                table: "Testing");
        }
    }
}
