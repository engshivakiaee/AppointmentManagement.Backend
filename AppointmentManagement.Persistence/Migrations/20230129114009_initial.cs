using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentManagement.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<TimeSpan>(type: "time", nullable: false),
                    To = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgentAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentAvailabilities_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentAvailabilities_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentAvailabilityId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerMessage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AgentAvailabilities_AgentAvailabilityId",
                        column: x => x.AgentAvailabilityId,
                        principalTable: "AgentAvailabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Shiva", "Kiaee", "07123456789" },
                    { 2, "Eva", "King", "07123456710" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "From", "To" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 2, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 3, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 4, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { 5, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 6, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 12, 0, 0, 0) },
                    { 7, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 8, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 9, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 10, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 11, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 14, 30, 0, 0) },
                    { 12, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 13, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 15, 30, 0, 0) },
                    { 14, new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { 15, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 16, 30, 0, 0) },
                    { 16, new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 17, 0, 0, 0) },
                    { 17, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 17, 30, 0, 0) },
                    { 18, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 18, 0, 0, 0) },
                    { 19, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 18, 30, 0, 0) },
                    { 20, new TimeSpan(0, 18, 30, 0, 0), new TimeSpan(0, 19, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "AgentAvailabilities",
                columns: new[] { "Id", "AgentId", "Date", "TimeSlotId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 3, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 4, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 5, 2, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 6, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 7, 1, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 8, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 9, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 10, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 11, 2, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 12, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 13, 1, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 14, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 15, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 16, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 17, 2, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 18, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 19, 1, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 20, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 21, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 22, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 23, 2, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 24, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 25, 1, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 26, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 27, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 28, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 29, 2, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 30, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 31, 1, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 32, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 33, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 34, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 35, 2, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 36, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 37, 1, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 7 },
                    { 38, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 7 },
                    { 39, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 7 },
                    { 40, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 7 },
                    { 41, 2, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 7 },
                    { 42, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7 }
                });

            migrationBuilder.InsertData(
                table: "AgentAvailabilities",
                columns: new[] { "Id", "AgentId", "Date", "TimeSlotId" },
                values: new object[,]
                {
                    { 43, 1, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 8 },
                    { 44, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 8 },
                    { 45, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 8 },
                    { 46, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 8 },
                    { 47, 2, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 8 },
                    { 48, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8 },
                    { 49, 1, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 9 },
                    { 50, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 9 },
                    { 51, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 9 },
                    { 52, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 9 },
                    { 53, 2, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 9 },
                    { 54, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9 },
                    { 55, 1, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 10 },
                    { 56, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc), 10 },
                    { 57, 1, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 10 },
                    { 58, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc), 10 },
                    { 59, 2, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 10 },
                    { 60, 1, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentAvailabilities_AgentId",
                table: "AgentAvailabilities",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentAvailabilities_TimeSlotId",
                table: "AgentAvailabilities",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AgentAvailabilityId",
                table: "Appointments",
                column: "AgentAvailabilityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AgentAvailabilities");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "TimeSlots");
        }
    }
}
