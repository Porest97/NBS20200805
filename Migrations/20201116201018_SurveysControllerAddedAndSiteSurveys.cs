using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class SurveysControllerAddedAndSiteSurveys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteSurveyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteSurveyStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSurveyStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSurvey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteSurveyNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Scheduled = table.Column<DateTime>(nullable: true),
                    Started = table.Column<DateTime>(nullable: true),
                    Ended = table.Column<DateTime>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    IncidentId = table.Column<int>(nullable: true),
                    FloorOneDescription = table.Column<string>(nullable: true),
                    ImageModelId = table.Column<int>(nullable: true),
                    ImageModelId1 = table.Column<int>(nullable: true),
                    ImageModelId2 = table.Column<int>(nullable: true),
                    ImageModelId3 = table.Column<int>(nullable: true),
                    ImageModelId4 = table.Column<int>(nullable: true),
                    FloorTwoDescription = table.Column<string>(nullable: true),
                    ImageModelId5 = table.Column<int>(nullable: true),
                    ImageModelId6 = table.Column<int>(nullable: true),
                    ImageModelId7 = table.Column<int>(nullable: true),
                    ImageModelId8 = table.Column<int>(nullable: true),
                    ImageModelId9 = table.Column<int>(nullable: true),
                    FloorThreeDescription = table.Column<string>(nullable: true),
                    ImageModelId10 = table.Column<int>(nullable: true),
                    ImageModelId11 = table.Column<int>(nullable: true),
                    ImageModelId12 = table.Column<int>(nullable: true),
                    ImageModelId13 = table.Column<int>(nullable: true),
                    ImageModelId14 = table.Column<int>(nullable: true),
                    FloorFourDescription = table.Column<string>(nullable: true),
                    ImageModelId15 = table.Column<int>(nullable: true),
                    ImageModelId16 = table.Column<int>(nullable: true),
                    ImageModelId17 = table.Column<int>(nullable: true),
                    ImageModelId18 = table.Column<int>(nullable: true),
                    ImageModelId19 = table.Column<int>(nullable: true),
                    FloorFiveDescription = table.Column<string>(nullable: true),
                    ImageModelId20 = table.Column<int>(nullable: true),
                    ImageModelId21 = table.Column<int>(nullable: true),
                    ImageModelId22 = table.Column<int>(nullable: true),
                    ImageModelId23 = table.Column<int>(nullable: true),
                    ImageModelId24 = table.Column<int>(nullable: true),
                    SiteSurveyStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSurvey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId",
                        column: x => x.ImageModelId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId1",
                        column: x => x.ImageModelId1,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId10",
                        column: x => x.ImageModelId10,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId11",
                        column: x => x.ImageModelId11,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId12",
                        column: x => x.ImageModelId12,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId13",
                        column: x => x.ImageModelId13,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId14",
                        column: x => x.ImageModelId14,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId15",
                        column: x => x.ImageModelId15,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId16",
                        column: x => x.ImageModelId16,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId17",
                        column: x => x.ImageModelId17,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId18",
                        column: x => x.ImageModelId18,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId19",
                        column: x => x.ImageModelId19,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId2",
                        column: x => x.ImageModelId2,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId20",
                        column: x => x.ImageModelId20,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId21",
                        column: x => x.ImageModelId21,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId22",
                        column: x => x.ImageModelId22,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId23",
                        column: x => x.ImageModelId23,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId24",
                        column: x => x.ImageModelId24,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId3",
                        column: x => x.ImageModelId3,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId4",
                        column: x => x.ImageModelId4,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId5",
                        column: x => x.ImageModelId5,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId6",
                        column: x => x.ImageModelId6,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId7",
                        column: x => x.ImageModelId7,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId8",
                        column: x => x.ImageModelId8,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Images_ImageModelId9",
                        column: x => x.ImageModelId9,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_Incident_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteSurvey_SiteSurveyStatus_SiteSurveyStatusId",
                        column: x => x.SiteSurveyStatusId,
                        principalTable: "SiteSurveyStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ApplicationUserId",
                table: "SiteSurvey",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId",
                table: "SiteSurvey",
                column: "ImageModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId1",
                table: "SiteSurvey",
                column: "ImageModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId10",
                table: "SiteSurvey",
                column: "ImageModelId10");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId11",
                table: "SiteSurvey",
                column: "ImageModelId11");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId12",
                table: "SiteSurvey",
                column: "ImageModelId12");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId13",
                table: "SiteSurvey",
                column: "ImageModelId13");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId14",
                table: "SiteSurvey",
                column: "ImageModelId14");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId15",
                table: "SiteSurvey",
                column: "ImageModelId15");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId16",
                table: "SiteSurvey",
                column: "ImageModelId16");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId17",
                table: "SiteSurvey",
                column: "ImageModelId17");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId18",
                table: "SiteSurvey",
                column: "ImageModelId18");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId19",
                table: "SiteSurvey",
                column: "ImageModelId19");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId2",
                table: "SiteSurvey",
                column: "ImageModelId2");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId20",
                table: "SiteSurvey",
                column: "ImageModelId20");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId21",
                table: "SiteSurvey",
                column: "ImageModelId21");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId22",
                table: "SiteSurvey",
                column: "ImageModelId22");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId23",
                table: "SiteSurvey",
                column: "ImageModelId23");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId24",
                table: "SiteSurvey",
                column: "ImageModelId24");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId3",
                table: "SiteSurvey",
                column: "ImageModelId3");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId4",
                table: "SiteSurvey",
                column: "ImageModelId4");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId5",
                table: "SiteSurvey",
                column: "ImageModelId5");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId6",
                table: "SiteSurvey",
                column: "ImageModelId6");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId7",
                table: "SiteSurvey",
                column: "ImageModelId7");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId8",
                table: "SiteSurvey",
                column: "ImageModelId8");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_ImageModelId9",
                table: "SiteSurvey",
                column: "ImageModelId9");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_IncidentId",
                table: "SiteSurvey",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSurvey_SiteSurveyStatusId",
                table: "SiteSurvey",
                column: "SiteSurveyStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteSurvey");

            migrationBuilder.DropTable(
                name: "SiteSurveyStatus");
        }
    }
}
