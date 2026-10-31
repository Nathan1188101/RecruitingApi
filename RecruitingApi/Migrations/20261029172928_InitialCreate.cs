using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitingApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFullTime = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecruitingEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitingEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecruitingEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrations_RecruitingEvents_RecruitingEventId",
                        column: x => x.RecruitingEventId,
                        principalTable: "RecruitingEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Occupations",
                columns: new[] { "Id", "Category", "IsFullTime", "Title" },
                values: new object[,]
                {
                    { 1, "IT", true, "Software Engineer" },
                    { 2, "It", true, "Backend Engineer" },
                    { 3, "IT", true, "Data Analyst" },
                    { 4, "Maintenance", true, "Janator" },
                    { 5, "Marking", true, "Marketing Agent" },
                    { 6, "Maintenance", false, "Painter" }
                });

            migrationBuilder.InsertData(
                table: "RecruitingEvents",
                columns: new[] { "Id", "Capacity", "Date", "EventTitle", "Location" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2026, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR Thing", "Huntsville" },
                    { 2, 10, new DateTime(2026, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corperate Jargon", "Toronto" },
                    { 3, 22, new DateTime(2026, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Join the Military Now!", "Barrie" },
                    { 4, 45, new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stuff and Things", "Missisauga" },
                    { 5, 51, new DateTime(2026, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Why you should Join.", "Bracebridge" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "Id", "Email", "Name", "Phone", "RecruitingEventId" },
                values: new object[,]
                {
                    { 1, "Nathan@test.com", "Nathan", null, 1 },
                    { 2, "bob@bob.com", "Bob", "705-123-1234", 2 },
                    { 3, "Ferb@Ferb.com", "Ferb", null, 3 },
                    { 4, "Tim@fart.com", "Tim", null, 4 },
                    { 5, "wineteriscoming@got.com", "Bran", "123-456-7890", 5 },
                    { 6, "mario@mario&luigi.com", "Mario", "127-742-7508", 1 },
                    { 7, "link@hyrule.com", "Link", "742-723-8403", 1 },
                    { 8, "bowser@koopa.ca", "Bowser", "234-840-9374", 5 },
                    { 9, "mario@mario&luigi.com", "Wario", "748-838-2341", 5 },
                    { 10, "jane@wedabest.com", "Patrick Jane", "7057483937", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_Email_RecruitingEventId",
                table: "Registrations",
                columns: new[] { "Email", "RecruitingEventId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_RecruitingEventId",
                table: "Registrations",
                column: "RecruitingEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "RecruitingEvents");
        }
    }
}
