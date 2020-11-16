using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nation",
                columns: table => new
                {
                    NationName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nation", x => x.NationName);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mName = table.Column<string>(type: "TEXT", nullable: true),
                    Population = table.Column<int>(type: "INTEGER", nullable: false),
                    NationName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.MunicipalityID);
                    table.ForeignKey(
                        name: "FK_Municipality_Nation_NationName",
                        column: x => x.NationName,
                        principalTable: "Nation",
                        principalColumn: "NationName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citizen",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Sex = table.Column<string>(type: "TEXT", nullable: true),
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizen", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Citizen_Municipality_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Addr = table.Column<string>(type: "TEXT", nullable: false),
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Addr);
                    table.ForeignKey(
                        name: "FK_Location_Municipality_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Testcenter",
                columns: table => new
                {
                    CenterID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hours = table.Column<string>(type: "TEXT", nullable: true),
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testcenter", x => x.CenterID);
                    table.ForeignKey(
                        name: "FK_Testcenter_Municipality_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CitizenLocation",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Addr = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenLocation", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_CitizenLocation_Citizen_SSN",
                        column: x => x.SSN,
                        principalTable: "Citizen",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitizenLocation_Location_Addr",
                        column: x => x.Addr,
                        principalTable: "Location",
                        principalColumn: "Addr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Testcentermanagement",
                columns: table => new
                {
                    PhoneNum = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    CenterID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testcentermanagement", x => x.PhoneNum);
                    table.ForeignKey(
                        name: "FK_Testcentermanagement_Testcenter_CenterID",
                        column: x => x.CenterID,
                        principalTable: "Testcenter",
                        principalColumn: "CenterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestedAt",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Result = table.Column<bool>(type: "INTEGER", nullable: false),
                    CenterID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestedAt", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_TestedAt_Citizen_SSN",
                        column: x => x.SSN,
                        principalTable: "Citizen",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestedAt_Testcenter_CenterID",
                        column: x => x.CenterID,
                        principalTable: "Testcenter",
                        principalColumn: "CenterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citizen_MunicipalityID",
                table: "Citizen",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenLocation_Addr",
                table: "CitizenLocation",
                column: "Addr");

            migrationBuilder.CreateIndex(
                name: "IX_Location_MunicipalityID",
                table: "Location",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_NationName",
                table: "Municipality",
                column: "NationName");

            migrationBuilder.CreateIndex(
                name: "IX_Testcenter_MunicipalityID",
                table: "Testcenter",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Testcentermanagement_CenterID",
                table: "Testcentermanagement",
                column: "CenterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestedAt_CenterID",
                table: "TestedAt",
                column: "CenterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitizenLocation");

            migrationBuilder.DropTable(
                name: "Testcentermanagement");

            migrationBuilder.DropTable(
                name: "TestedAt");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Citizen");

            migrationBuilder.DropTable(
                name: "Testcenter");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "Nation");
        }
    }
}
