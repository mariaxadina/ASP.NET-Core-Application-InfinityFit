using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityFit.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueLikeConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Likes_UserId",
                table: "Likes");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 20, 12, 55, 5, 840, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 20, 12, 55, 5, 840, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 20, 12, 55, 5, 840, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "DateOfCreation",
                value: new DateTime(2026, 1, 20, 12, 55, 5, 840, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId_PostId",
                table: "Likes",
                columns: new[] { "UserId", "PostId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Likes_UserId_PostId",
                table: "Likes");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "DateOfCreation",
                value: new DateTime(2025, 12, 10, 22, 59, 28, 559, DateTimeKind.Local).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "DateOfCreation",
                value: new DateTime(2025, 12, 10, 22, 59, 28, 559, DateTimeKind.Local).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "DateOfCreation",
                value: new DateTime(2025, 12, 10, 22, 59, 28, 559, DateTimeKind.Local).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "DateOfCreation",
                value: new DateTime(2025, 12, 10, 22, 59, 28, 559, DateTimeKind.Local).AddTicks(6229));

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");
        }
    }
}
