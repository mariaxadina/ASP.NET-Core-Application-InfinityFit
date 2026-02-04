using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfinityFit.Migrations
{
    /// <inheritdoc />
    public partial class Vouchere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vouchers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000020"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000250"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000010"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000020"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000005000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000005"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000015"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000050"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000100"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9940));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000250"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9942));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000500"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000001000"),
                column: "DateOfCreation",
                value: new DateTime(2026, 2, 4, 3, 8, 7, 642, DateTimeKind.Local).AddTicks(9949));

            migrationBuilder.InsertData(
                table: "Vouchers",
                columns: new[] { "Id", "Code", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "5E8EC987", "Reducere de 10% la intrarea la muzeu", "10% Reducere Muzeu", null },
                    { 2, "B0A7F515", "Reducere de 15% la un landmark turistic", "15% Reducere Landmark", null },
                    { 3, "B75BEA4C", "Reducere de 20% la restaurantul partener", "20% Reducere Restaurant", null },
                    { 4, "AACC17C7", "Reducere de 25% la turul ghidat al orașului", "25% Reducere Tur", null },
                    { 5, "7368632B", "Reducere de 30% la parcul de aventură", "30% Reducere Adventure Park", null },
                    { 6, "68CF069D", "Reducere de 35% la parcul de aventură", "35% Reducere Adventure Park", null },
                    { 7, "78855E9A", "Reducere de 40% la o cazare parteneră", "40% Reducere Cazare", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_UserId",
                table: "Vouchers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vouchers");

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
        }
    }
}
