using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntroSEProject.Models.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2023, 1, 30, 15, 6, 57, 733, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2023, 3, 20, 3, 52, 8, 193, DateTimeKind.Local).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2023, 2, 16, 0, 45, 36, 843, DateTimeKind.Local).AddTicks(4576));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2023, 7, 25, 4, 1, 25, 759, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2023, 1, 27, 18, 42, 22, 503, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2023, 10, 31, 22, 49, 42, 408, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfBirth",
                value: new DateTime(2023, 11, 26, 18, 6, 51, 728, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateOfBirth",
                value: new DateTime(2023, 6, 4, 0, 12, 29, 732, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateOfBirth",
                value: new DateTime(2023, 3, 24, 14, 24, 45, 295, DateTimeKind.Local).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateOfBirth",
                value: new DateTime(2023, 10, 16, 0, 36, 11, 547, DateTimeKind.Local).AddTicks(6220));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2023, 1, 30, 11, 45, 17, 856, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2023, 3, 20, 0, 30, 28, 316, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2023, 2, 15, 21, 23, 56, 966, DateTimeKind.Local).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateOfBirth",
                value: new DateTime(2023, 7, 25, 0, 39, 45, 883, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateOfBirth",
                value: new DateTime(2023, 1, 27, 15, 20, 42, 626, DateTimeKind.Local).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateOfBirth",
                value: new DateTime(2023, 10, 31, 19, 28, 2, 531, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfBirth",
                value: new DateTime(2023, 11, 26, 14, 45, 11, 851, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateOfBirth",
                value: new DateTime(2023, 6, 3, 20, 50, 49, 855, DateTimeKind.Local).AddTicks(5294));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateOfBirth",
                value: new DateTime(2023, 3, 24, 11, 3, 5, 418, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateOfBirth",
                value: new DateTime(2023, 10, 15, 21, 14, 31, 670, DateTimeKind.Local).AddTicks(7087));
        }
    }
}
