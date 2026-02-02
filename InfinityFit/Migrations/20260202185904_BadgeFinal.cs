using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityFit.Migrations
{
    /// <inheritdoc />
    public partial class BadgeFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000000"),
                columns: new[] { "DateOfCreation", "Icon" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8329), "/images/welcome.png" });

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000020"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000250"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000010"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000020"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000005000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000015"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000250"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8481));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8486));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000000"),
                columns: new[] { "DateOfCreation", "Icon" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7793), "/images/1.png" });

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000020"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000250"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000010"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000020"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000005000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000015"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000250"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7981));
        }
    }
}
