using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityFit.Migrations
{
    /// <inheritdoc />
    public partial class AddDailyLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyLocations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 31, 14, 23, 0, 82, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 31, 14, 23, 0, 82, DateTimeKind.Local).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 31, 14, 23, 0, 82, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 31, 14, 23, 0, 82, DateTimeKind.Local).AddTicks(6622));

            migrationBuilder.CreateIndex(
                name: "IX_DailyLocations_UserId",
                table: "DailyLocations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyLocations");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 25, 0, 38, 27, 202, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 25, 0, 38, 27, 202, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 25, 0, 38, 27, 202, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 25, 0, 38, 27, 202, DateTimeKind.Local).AddTicks(8497));
        }
    }
}
