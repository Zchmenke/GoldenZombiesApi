using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoldenZombiesApiProject.Migrations
{
    /// <inheritdoc />
    public partial class initialcreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProjectStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    HoursWorked = table.Column<double>(type: "float", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeReports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeReports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Title" },
                values: new object[,]
                {
                    { 1, "Henriks.Mail@Hotmail.com", "Henrik", "Rydén", "Junior" },
                    { 2, "Kenny.Mail@Hotmail.com", "Kenny", "Lindblom", "Junior" },
                    { 3, "John.Mail@Hotmail.com", "John", "Albrektsson", "Junior" },
                    { 4, "Lars.Mail@Hotmail.com", "Lars", "Laxsson", "Senior" },
                    { 5, "Johanna.Mail@Hotmail.com", "Johanna", "Svensson", "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "IsActive", "ProjectEnd", "ProjectName", "ProjectStart" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "BankApplication", new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ShoppingWebsite", new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build API", new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, false, null, "Quiz Game", new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, true, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desktop Application", new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "Id", "EmployeeId", "HoursWorked", "ProjectId", "WeekNumber" },
                values: new object[,]
                {
                    { 1, 1, 40.200000000000003, 1, 8 },
                    { 2, 1, 10.199999999999999, 2, 7 },
                    { 3, 2, 20.399999999999999, 1, 8 },
                    { 4, 2, 22.300000000000001, 4, 4 },
                    { 5, 3, 20.199999999999999, 4, 7 },
                    { 6, 3, 30.100000000000001, 2, 6 },
                    { 7, 4, 40.200000000000003, 5, 8 },
                    { 8, 4, 30.199999999999999, 4, 7 },
                    { 9, 5, 20.199999999999999, 1, 4 },
                    { 10, 5, 30.100000000000001, 3, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_EmployeeId",
                table: "TimeReports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_ProjectId",
                table: "TimeReports",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
