using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace TimeReporter.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerId);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Frozen = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subactivities",
                columns: table => new
                {
                    SubactivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subactivities", x => x.SubactivityId);
                    table.ForeignKey(
                        name: "FK_Subactivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accepted",
                columns: table => new
                {
                    AcceptedTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accepted", x => x.AcceptedTimeId);
                    table.ForeignKey(
                        name: "FK_Accepted_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accepted_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accepted_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    SubactivityId = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_Entries_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_Subactivities_SubactivityId",
                        column: x => x.SubactivityId,
                        principalTable: "Subactivities",
                        principalColumn: "SubactivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entries_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "WorkerId", "Name" },
                values: new object[,]
                {
                    { 1, "Clarkson" },
                    { 2, "Hammond" },
                    { 3, "May" },
                    { 4, "Plant" },
                    { 5, "Page" },
                    { 6, "Bonham" },
                    { 7, "Jones" },
                    { 8, "Hetfield" },
                    { 9, "Hammett" },
                    { 10, "Ulrich" },
                    { 11, "Trujillo" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Active", "Budget", "Code", "Name", "WorkerId" },
                values: new object[,]
                {
                    { 1, true, 115, "Mercury-1", "Mercury", 1 },
                    { 2, true, 50, "Jupiter-2", "Jupiter", 2 },
                    { 9, true, 150, "Luna-1", "Luna", 9 },
                    { 3, true, 100, "Pluto-1", "Pluto", 3 },
                    { 4, true, 100, "Saturn-5", "Saturn", 4 },
                    { 8, true, 150, "Neptune-7", "Neptune", 8 },
                    { 5, true, -10, "Venus-3", "Venus", 5 },
                    { 10, true, 300, "Europa-77", "Europa", 10 },
                    { 6, true, 70, "Uranus-2", "Uranus", 6 },
                    { 7, true, -1, "OTHER", "Other", 7 }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Date", "Frozen", "WorkerId" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), false, 9 },
                    { 8, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), false, 8 },
                    { 7, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), false, 7 },
                    { 5, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), false, 5 },
                    { 4, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), true, 4 },
                    { 3, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), false, 3 },
                    { 2, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), false, 2 },
                    { 1, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), true, 1 },
                    { 6, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), false, 6 },
                    { 10, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), false, 10 }
                });

            migrationBuilder.InsertData(
                table: "Accepted",
                columns: new[] { "AcceptedTimeId", "ActivityId", "ReportId", "Time", "WorkerId" },
                values: new object[,]
                {
                    { 1, 2, 1, 50, 1 },
                    { 3, 3, 1, 25, 1 },
                    { 5, 8, 4, 150, 4 },
                    { 4, 2, 4, 100, 4 },
                    { 7, 5, 4, 160, 4 },
                    { 6, 7, 4, 110, 4 },
                    { 2, 7, 1, 110, 1 }
                });

            migrationBuilder.InsertData(
                table: "Subactivities",
                columns: new[] { "SubactivityId", "ActivityId", "Code" },
                values: new object[,]
                {
                    { 1, 1, "database" },
                    { 8, 8, "database" },
                    { 7, 7, "" },
                    { 5, 5, "database" },
                    { 9, 9, "database" },
                    { 4, 4, "database" },
                    { 3, 3, "database" },
                    { 2, 2, "database" },
                    { 6, 6, "database" },
                    { 10, 10, "database" }
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "EntryId", "ActivityId", "Date", "Description", "ReportId", "SubactivityId", "Time", "WorkerId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), "created table", 1, 2, 70, 1 },
                    { 4, 2, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), "edited row", 4, 2, 70, 4 },
                    { 3, 3, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), "added row", 1, 3, 30, 1 },
                    { 8, 3, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), "created table", 8, 3, 70, 8 },
                    { 7, 5, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), "created table", 4, 5, 30, 4 },
                    { 2, 7, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), "tea time", 1, 7, 150, 1 },
                    { 6, 7, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), "resting", 4, 7, 30, 4 },
                    { 5, 8, new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Local), "added column", 4, 8, 150, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accepted_ActivityId",
                table: "Accepted",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Accepted_ReportId",
                table: "Accepted",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Accepted_WorkerId",
                table: "Accepted",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_WorkerId",
                table: "Activities",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ActivityId",
                table: "Entries",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ReportId",
                table: "Entries",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_SubactivityId",
                table: "Entries",
                column: "SubactivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_WorkerId",
                table: "Entries",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_WorkerId",
                table: "Reports",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subactivities_ActivityId",
                table: "Subactivities",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accepted");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Subactivities");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
