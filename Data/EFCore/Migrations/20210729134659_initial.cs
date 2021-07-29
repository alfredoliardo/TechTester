using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.EFCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Bank = table.Column<string>(type: "TEXT", nullable: false),
                    OU = table.Column<string>(type: "TEXT", nullable: false),
                    Info = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => new { x.Bank, x.OU });
                });

            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Help = table.Column<string>(type: "TEXT", nullable: true),
                    HasNotRelevantOption = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workstations",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Bank = table.Column<string>(type: "TEXT", nullable: true),
                    OU = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workstations", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Workstations_Branches_Bank_OU",
                        columns: x => new { x.Bank, x.OU },
                        principalTable: "Branches",
                        principalColumns: new[] { "Bank", "OU" },
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TestChecks",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CheckId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisplayOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestChecks", x => new { x.TestId, x.CheckId });
                    table.ForeignKey(
                        name: "FK_TestChecks_Checks_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Checks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestChecks_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestInstances",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkstationName = table.Column<string>(type: "TEXT", nullable: false),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestInstances", x => new { x.TestId, x.WorkstationName });
                    table.ForeignKey(
                        name: "FK_TestInstances_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TestInstances_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestInstances_Workstations_WorkstationName",
                        column: x => x.WorkstationName,
                        principalTable: "Workstations",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCheckResponses",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkstationName = table.Column<string>(type: "TEXT", nullable: false),
                    CheckId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCheckResponses", x => new { x.TestId, x.WorkstationName, x.CheckId });
                    table.ForeignKey(
                        name: "FK_TestCheckResponses_TestChecks_TestId_CheckId",
                        columns: x => new { x.TestId, x.CheckId },
                        principalTable: "TestChecks",
                        principalColumns: new[] { "TestId", "CheckId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestCheckResponses_TestInstances_TestId_WorkstationName",
                        columns: x => new { x.TestId, x.WorkstationName },
                        principalTable: "TestInstances",
                        principalColumns: new[] { "TestId", "WorkstationName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestInstanceNotes",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkstationName = table.Column<string>(type: "TEXT", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestInstanceNotes", x => new { x.TestId, x.WorkstationName, x.CreationTime });
                    table.ForeignKey(
                        name: "FK_TestInstanceNotes_TestInstances_TestId_WorkstationName",
                        columns: x => new { x.TestId, x.WorkstationName },
                        principalTable: "TestInstances",
                        principalColumns: new[] { "TestId", "WorkstationName" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestCheckResponses_TestId_CheckId",
                table: "TestCheckResponses",
                columns: new[] { "TestId", "CheckId" });

            migrationBuilder.CreateIndex(
                name: "IX_TestChecks_CheckId",
                table: "TestChecks",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_TestInstances_GroupId",
                table: "TestInstances",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TestInstances_WorkstationName",
                table: "TestInstances",
                column: "WorkstationName");

            migrationBuilder.CreateIndex(
                name: "IX_Workstations_Bank_OU",
                table: "Workstations",
                columns: new[] { "Bank", "OU" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestCheckResponses");

            migrationBuilder.DropTable(
                name: "TestInstanceNotes");

            migrationBuilder.DropTable(
                name: "TestChecks");

            migrationBuilder.DropTable(
                name: "TestInstances");

            migrationBuilder.DropTable(
                name: "Checks");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Workstations");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
