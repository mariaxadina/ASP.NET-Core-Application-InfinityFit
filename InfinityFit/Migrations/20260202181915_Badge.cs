using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfinityFit.Migrations
{
    /// <inheritdoc />
    public partial class Badge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM UserBadges
                WHERE BadgeId IN (
                    '11111111-1111-1111-1111-111111111111',
                    '22222222-2222-2222-2222-222222222222',
                    '33333333-3333-3333-3333-333333333333',
                    '44444444-4444-4444-4444-444444444444'
                )
            ");

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DateOfCreation", "Description", "Icon", "Name" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000000"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7793), "You have created your account!", "/images/1.png", "Welcome" },
                    { new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7860), "You posted for the first time", "/images/post1.png", "First Post" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7865), "You made 5 posts", "/images/post5.png", "Traveler" },
                    { new Guid("10000000-0000-0000-0000-000000000020"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7869), "You made 20 posts", "/images/post20.png", "Explorer" },
                    { new Guid("10000000-0000-0000-0000-000000000050"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7872), "You made 50 posts", "/images/post50.png", "Adventurer" },
                    { new Guid("10000000-0000-0000-0000-000000000100"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7878), "You made 100 posts", "/images/post100.png", "Storyteller" },
                    { new Guid("10000000-0000-0000-0000-000000000250"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7885), "You made 250 posts", "/images/post250.png", "Content Creator" },
                    { new Guid("10000000-0000-0000-0000-000000000500"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7906), "You made 500 posts", "/images/post500.png", "Master Explorer" },
                    { new Guid("10000000-0000-0000-0000-000000001000"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7919), "You made 1,000 posts", "/images/post1000.png", "Legendary Poster" },
                    { new Guid("20000000-0000-0000-0000-000000000005"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7925), "Reached level 5", "/images/level5.png", "Getting Started" },
                    { new Guid("20000000-0000-0000-0000-000000000010"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7930), "Reached level 10", "/images/level10.png", "Rising Star" },
                    { new Guid("20000000-0000-0000-0000-000000000020"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7933), "Reached level 20", "/images/level20.png", "Challenger" },
                    { new Guid("20000000-0000-0000-0000-000000000050"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7935), "Reached level 50", "/images/level50.png", "Veteran Explorer" },
                    { new Guid("20000000-0000-0000-0000-000000000100"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7938), "Reached level 100", "/images/level100.png", "Legend of InfinityFit" },
                    { new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7940), "Gave your first like", "/images/like1.png", "First Love" },
                    { new Guid("30000000-0000-0000-0000-000000000010"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7947), "Gave 10 likes", "/images/like10.png", "Supporter" },
                    { new Guid("30000000-0000-0000-0000-000000000050"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7949), "Gave 50 likes", "/images/like50.png", "Positive Vibes" },
                    { new Guid("30000000-0000-0000-0000-000000000100"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7952), "Gave 100 likes", "/images/like100.png", "Community Booster" },
                    { new Guid("30000000-0000-0000-0000-000000000500"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7954), "Gave 500 likes", "/images/like500.png", "Influencer" },
                    { new Guid("30000000-0000-0000-0000-000000001000"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7958), "Gave 1,000 likes", "/images/like1000.png", "Social Machine" },
                    { new Guid("30000000-0000-0000-0000-000000005000"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7961), "Gave 5,000 likes", "/images/like5000.png", "Infinity Reactor" },
                    { new Guid("40000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7963), "Posted your first comment", "/images/comment1.png", "First Words" },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7965), "Posted 5 comments", "/images/comment5.png", "Conversationalist" },
                    { new Guid("40000000-0000-0000-0000-000000000015"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7969), "Posted 15 comments", "/images/comment15.png", "Active Voice" },
                    { new Guid("40000000-0000-0000-0000-000000000050"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7972), "Posted 50 comments", "/images/comment50.png", "Discussion Leader" },
                    { new Guid("40000000-0000-0000-0000-000000000100"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7974), "Posted 100 comments", "/images/comment100.png", "Community Speaker" },
                    { new Guid("40000000-0000-0000-0000-000000000250"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7976), "Posted 250 comments", "/images/comment250.png", "Debater Pro" },
                    { new Guid("40000000-0000-0000-0000-000000000500"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7979), "Posted 500 comments", "/images/comment500.png", "Social Anchor" },
                    { new Guid("40000000-0000-0000-0000-000000001000"), new DateTime(2026, 2, 2, 20, 19, 14, 781, DateTimeKind.Local).AddTicks(7981), "Posted 1,000 comments", "/images/comment1000.png", "Voice of Infinity" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000100"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000250"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000500"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000001000"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000100"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000100"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000500"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000001000"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000005000"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000100"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000250"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000500"));

            migrationBuilder.DeleteData(
                table: "Badges",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000001000"));

            migrationBuilder.InsertData(
                table: "Badges",
                columns: new[] { "Id", "DateOfCreation", "Description", "Icon", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 2, 2, 18, 10, 34, 425, DateTimeKind.Local).AddTicks(9960), "Ți-ai creat contul", "/images/1.png", "Welcome" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 2, 2, 18, 10, 34, 426, DateTimeKind.Local).AddTicks(26), "Ai făcut prima ta postare", "/images/2.png", "First Post" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 2, 2, 18, 10, 34, 426, DateTimeKind.Local).AddTicks(30), "Ai făcut 5 postări", "/images/3.png", "Traveler" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 2, 2, 18, 10, 34, 426, DateTimeKind.Local).AddTicks(33), "Ai făcut 20 de postări", "/images/4.png", "Explorer" }
                });
        }
    }
}
