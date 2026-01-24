using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityFit.Migrations
{
    /// <inheritdoc />
    public partial class LeaderboardModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalEngagement",
                table: "LeaderboardEntries",
                newName: "Engagement");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 24, 1, 31, 31, 961, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 24, 1, 31, 31, 961, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 24, 1, 31, 31, 961, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 24, 1, 31, 31, 961, DateTimeKind.Local).AddTicks(7905));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Engagement",
                table: "LeaderboardEntries",
                newName: "TotalEngagement");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 24, 1, 14, 11, 451, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 24, 1, 14, 11, 451, DateTimeKind.Local).AddTicks(2347));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 24, 1, 14, 11, 451, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 24, 1, 14, 11, 451, DateTimeKind.Local).AddTicks(2366));
        }
    }
}
