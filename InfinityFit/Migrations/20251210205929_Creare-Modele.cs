using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityFit.Migrations
{
    /// <inheritdoc />
    public partial class CreareModele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Badges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "DateOfCreation", "Icon" },
                values: new object[] { new DateTime(2025, 12, 10, 22, 59, 28, 559, DateTimeKind.Local).AddTicks(6155), "/images/1.png" });

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "DateOfCreation", "Icon" },
                values: new object[] { new DateTime(2025, 12, 10, 22, 59, 28, 559, DateTimeKind.Local).AddTicks(6223), "/images/2.png" });

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "DateOfCreation", "Icon" },
                values: new object[] { new DateTime(2025, 12, 10, 22, 59, 28, 559, DateTimeKind.Local).AddTicks(6227), "/images/3.png" });

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "DateOfCreation", "Icon" },
                values: new object[] { new DateTime(2025, 12, 10, 22, 59, 28, 559, DateTimeKind.Local).AddTicks(6229), "/images/4.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Badges");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "DateOfCreation",
                value: new DateTime(2025, 12, 10, 22, 4, 4, 566, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "DateOfCreation",
                value: new DateTime(2025, 12, 10, 22, 4, 4, 566, DateTimeKind.Local).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "DateOfCreation",
                value: new DateTime(2025, 12, 10, 22, 4, 4, 566, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "DateOfCreation",
                value: new DateTime(2025, 12, 10, 22, 4, 4, 566, DateTimeKind.Local).AddTicks(6906));
        }
    }
}
