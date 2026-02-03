using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityFit.Migrations
{
    /// <inheritdoc />
    public partial class AddDailySpinPlay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailySpinPlays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointsWon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySpinPlays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailySpinPlays_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000020"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6737));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000250"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000010"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000020"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6806));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000005000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000015"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6832));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000250"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 3, 22, 21, 43, 548, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.CreateIndex(
                name: "IX_DailySpinPlays_UserId",
                table: "DailySpinPlays",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailySpinPlays");

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 2, 20, 59, 4, 324, DateTimeKind.Local).AddTicks(8329));

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
    }
}
