using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FGHomeLife.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogPostBlogTagTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6137));

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6211));

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 3, 13, 6, 37, 546, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 3, 19, 6, 37, 546, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 30, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 3, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6451));

            migrationBuilder.UpdateData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 1, 6, 37, 546, DateTimeKind.Local).AddTicks(2483));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 3, 12, 46, 57, 642, DateTimeKind.Local).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 3, 18, 46, 57, 642, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 30, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(4141));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 1, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 3, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 641, DateTimeKind.Local).AddTicks(9082));
        }
    }
}
