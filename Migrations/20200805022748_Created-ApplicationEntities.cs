using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS.Migrations
{
    public partial class CreatedApplicationEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyRoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentPriority",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentPriorityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentPriority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MtrlList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Item1 = table.Column<string>(nullable: true),
                    Item2 = table.Column<string>(nullable: true),
                    Item3 = table.Column<string>(nullable: true),
                    Item4 = table.Column<string>(nullable: true),
                    Item5 = table.Column<string>(nullable: true),
                    Item6 = table.Column<string>(nullable: true),
                    Item7 = table.Column<string>(nullable: true),
                    Item8 = table.Column<string>(nullable: true),
                    Item9 = table.Column<string>(nullable: true),
                    Item10 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MtrlList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NABLogStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NABLogStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NABLogStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SwishNumber = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PONumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    POHours = table.Column<decimal>(nullable: false),
                    DateTimeApproved = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteRoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WLogStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WLogStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WLogStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyNumber = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CompanyRoleId = table.Column<int>(nullable: true),
                    CompanyStatusId = table.Column<int>(nullable: true),
                    CompanyTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_CompanyRole_CompanyRoleId",
                        column: x => x.CompanyRoleId,
                        principalTable: "CompanyRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_CompanyStatus_CompanyStatusId",
                        column: x => x.CompanyStatusId,
                        principalTable: "CompanyStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_CompanyType_CompanyTypeId",
                        column: x => x.CompanyTypeId,
                        principalTable: "CompanyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonRoleId = table.Column<int>(nullable: true),
                    PersonStatusId = table.Column<int>(nullable: true),
                    PersonTypeId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Ssn = table.Column<string>(nullable: true),
                    PhoneNumber1 = table.Column<string>(nullable: true),
                    PhoneNumber2 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PersonAccountsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_PersonAccounts_PersonAccountsId",
                        column: x => x.PersonAccountsId,
                        principalTable: "PersonAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_PersonRole_PersonRoleId",
                        column: x => x.PersonRoleId,
                        principalTable: "PersonRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_PersonStatus_PersonStatusId",
                        column: x => x.PersonStatusId,
                        principalTable: "PersonStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_PersonType_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteNumber = table.Column<string>(nullable: true),
                    SiteName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    NumberOfFloors = table.Column<string>(nullable: true),
                    SiteNotes = table.Column<string>(nullable: true),
                    SiteRoleId = table.Column<int>(nullable: true),
                    SiteStatusId = table.Column<int>(nullable: true),
                    SiteTypeId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Site_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Site_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Site_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Site_SiteRole_SiteRoleId",
                        column: x => x.SiteRoleId,
                        principalTable: "SiteRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Site_SiteStatus_SiteStatusId",
                        column: x => x.SiteStatusId,
                        principalTable: "SiteStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Site_SiteType_SiteTypeId",
                        column: x => x.SiteTypeId,
                        principalTable: "SiteType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(nullable: true),
                    AssetStatusId = table.Column<int>(nullable: true),
                    AssetTypeId = table.Column<int>(nullable: true),
                    BrandId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MACAddress = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    Connectivity = table.Column<string>(nullable: true),
                    LocalIP = table.Column<string>(nullable: true),
                    Ethernet1LLDP = table.Column<string>(nullable: true),
                    Ethernet1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AssetStatus_AssetStatusId",
                        column: x => x.AssetStatusId,
                        principalTable: "AssetStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentPriorityId = table.Column<int>(nullable: true),
                    IncidentStatusId = table.Column<int>(nullable: true),
                    IncidentTypeId = table.Column<int>(nullable: true),
                    IncidentNumber = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    SiteId = table.Column<int>(nullable: true),
                    Received = table.Column<DateTime>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    FEScheduled = table.Column<DateTime>(nullable: true),
                    PersonId2 = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FEEntersSite = table.Column<DateTime>(nullable: true),
                    FEEExitsSite = table.Column<DateTime>(nullable: true),
                    Logg = table.Column<string>(nullable: true),
                    IssueResolved = table.Column<DateTime>(nullable: true),
                    Resolution = table.Column<string>(nullable: true),
                    PurchaseOrderId = table.Column<int>(nullable: true),
                    MtrlListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incident_IncidentPriority_IncidentPriorityId",
                        column: x => x.IncidentPriorityId,
                        principalTable: "IncidentPriority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incident_IncidentStatus_IncidentStatusId",
                        column: x => x.IncidentStatusId,
                        principalTable: "IncidentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incident_IncidentType_IncidentTypeId",
                        column: x => x.IncidentTypeId,
                        principalTable: "IncidentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incident_MtrlList_MtrlListId",
                        column: x => x.MtrlListId,
                        principalTable: "MtrlList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incident_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incident_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incident_Person_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incident_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incident_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferIdenifyer = table.Column<string>(nullable: true),
                    DateTimeOffered = table.Column<DateTime>(nullable: true),
                    OfferStatusId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    SiteId = table.Column<int>(nullable: true),
                    IncidentId = table.Column<int>(nullable: true),
                    DateTimeScheduledStart = table.Column<DateTime>(nullable: true),
                    DateTimeScheduledEnd = table.Column<DateTime>(nullable: true),
                    HoursOnSite = table.Column<double>(nullable: false),
                    PricePerHour = table.Column<double>(nullable: false),
                    KostHours = table.Column<double>(nullable: false),
                    KostMtrl = table.Column<double>(nullable: false),
                    Riskfaktor = table.Column<double>(nullable: false),
                    TotalOfferAmount = table.Column<double>(nullable: false),
                    File = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_Incident_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offer_OfferStatus_OfferStatusId",
                        column: x => x.OfferStatusId,
                        principalTable: "OfferStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offer_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offer_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WLNumber = table.Column<string>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    DateTimeFrom = table.Column<DateTime>(nullable: true),
                    DateTimeTo = table.Column<DateTime>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    WLogStatusId = table.Column<int>(nullable: true),
                    IncidentId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WLog_Incident_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WLog_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WLog_WLogStatus_WLogStatusId",
                        column: x => x.WLogStatusId,
                        principalTable: "WLogStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NABLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentId = table.Column<int>(nullable: true),
                    DateTimeStarted = table.Column<DateTime>(nullable: true),
                    DateTimeEnded = table.Column<DateTime>(nullable: true),
                    LogNotes = table.Column<string>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    PriceHour = table.Column<decimal>(nullable: false),
                    MtrCost = table.Column<decimal>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    WLogId = table.Column<int>(nullable: true),
                    NABLogStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NABLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NABLog_Incident_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NABLog_NABLogStatus_NABLogStatusId",
                        column: x => x.NABLogStatusId,
                        principalTable: "NABLogStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NABLog_WLog_WLogId",
                        column: x => x.WLogId,
                        principalTable: "WLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: true),
                    CompanyId1 = table.Column<int>(nullable: true),
                    BillingDate = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    NABLogId = table.Column<int>(nullable: true),
                    NABLogId1 = table.Column<int>(nullable: true),
                    NABLogId2 = table.Column<int>(nullable: true),
                    NABLogId3 = table.Column<int>(nullable: true),
                    NABLogId4 = table.Column<int>(nullable: true),
                    BillingTerms = table.Column<string>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    PriceHour = table.Column<decimal>(nullable: false),
                    MtrCost = table.Column<decimal>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    BillStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_BillStatus_BillStatusId",
                        column: x => x.BillStatusId,
                        principalTable: "BillStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_NABLog_NABLogId",
                        column: x => x.NABLogId,
                        principalTable: "NABLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_NABLog_NABLogId1",
                        column: x => x.NABLogId1,
                        principalTable: "NABLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_NABLog_NABLogId2",
                        column: x => x.NABLogId2,
                        principalTable: "NABLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_NABLog_NABLogId3",
                        column: x => x.NABLogId3,
                        principalTable: "NABLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bill_NABLog_NABLogId4",
                        column: x => x.NABLogId4,
                        principalTable: "NABLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetStatusId",
                table: "Asset",
                column: "AssetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetTypeId",
                table: "Asset",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_BrandId",
                table: "Asset",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_SiteId",
                table: "Asset",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_BillStatusId",
                table: "Bill",
                column: "BillStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CompanyId",
                table: "Bill",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_CompanyId1",
                table: "Bill",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_NABLogId",
                table: "Bill",
                column: "NABLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_NABLogId1",
                table: "Bill",
                column: "NABLogId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_NABLogId2",
                table: "Bill",
                column: "NABLogId2");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_NABLogId3",
                table: "Bill",
                column: "NABLogId3");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_NABLogId4",
                table: "Bill",
                column: "NABLogId4");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyRoleId",
                table: "Company",
                column: "CompanyRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyStatusId",
                table: "Company",
                column: "CompanyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyTypeId",
                table: "Company",
                column: "CompanyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_IncidentPriorityId",
                table: "Incident",
                column: "IncidentPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_IncidentStatusId",
                table: "Incident",
                column: "IncidentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_IncidentTypeId",
                table: "Incident",
                column: "IncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_MtrlListId",
                table: "Incident",
                column: "MtrlListId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_PersonId",
                table: "Incident",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_PersonId1",
                table: "Incident",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_PersonId2",
                table: "Incident",
                column: "PersonId2");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_PurchaseOrderId",
                table: "Incident",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_SiteId",
                table: "Incident",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_NABLog_IncidentId",
                table: "NABLog",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_NABLog_NABLogStatusId",
                table: "NABLog",
                column: "NABLogStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_NABLog_WLogId",
                table: "NABLog",
                column: "WLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_IncidentId",
                table: "Offer",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_OfferStatusId",
                table: "Offer",
                column: "OfferStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_PersonId",
                table: "Offer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_SiteId",
                table: "Offer",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CompanyId",
                table: "Person",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonAccountsId",
                table: "Person",
                column: "PersonAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonRoleId",
                table: "Person",
                column: "PersonRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonStatusId",
                table: "Person",
                column: "PersonStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonTypeId",
                table: "Person",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_CompanyId",
                table: "Site",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_PersonId",
                table: "Site",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_PersonId1",
                table: "Site",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Site_SiteRoleId",
                table: "Site",
                column: "SiteRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_SiteStatusId",
                table: "Site",
                column: "SiteStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_SiteTypeId",
                table: "Site",
                column: "SiteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WLog_IncidentId",
                table: "WLog",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_WLog_PersonId",
                table: "WLog",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WLog_WLogStatusId",
                table: "WLog",
                column: "WLogStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "AssetStatus");

            migrationBuilder.DropTable(
                name: "AssetType");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "BillStatus");

            migrationBuilder.DropTable(
                name: "NABLog");

            migrationBuilder.DropTable(
                name: "OfferStatus");

            migrationBuilder.DropTable(
                name: "NABLogStatus");

            migrationBuilder.DropTable(
                name: "WLog");

            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "WLogStatus");

            migrationBuilder.DropTable(
                name: "IncidentPriority");

            migrationBuilder.DropTable(
                name: "IncidentStatus");

            migrationBuilder.DropTable(
                name: "IncidentType");

            migrationBuilder.DropTable(
                name: "MtrlList");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "SiteRole");

            migrationBuilder.DropTable(
                name: "SiteStatus");

            migrationBuilder.DropTable(
                name: "SiteType");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "PersonAccounts");

            migrationBuilder.DropTable(
                name: "PersonRole");

            migrationBuilder.DropTable(
                name: "PersonStatus");

            migrationBuilder.DropTable(
                name: "PersonType");

            migrationBuilder.DropTable(
                name: "CompanyRole");

            migrationBuilder.DropTable(
                name: "CompanyStatus");

            migrationBuilder.DropTable(
                name: "CompanyType");
        }
    }
}
