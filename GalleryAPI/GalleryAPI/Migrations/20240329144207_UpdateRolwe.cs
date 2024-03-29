using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRolwe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 29, 14, 42, 6, 64, DateTimeKind.Utc).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd2bb4aa-168b-4989-896b-4bc307e36e43", "AQAAAAIAAYagAAAAEAjSwgt+QsOwV7Z6BSuTMwCbK4tZJcnDZvc56bWE/uzRo8eYE2n5aD4aMblNgIFL+g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 29, 14, 31, 4, 795, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1eb29104-1355-402c-8503-ab487660033f", "AQAAAAIAAYagAAAAEAyxpuHuhZVxBywNDHudcwkF9Qu2Jhfa0lhpkcDGKt7TeRt0oeto1uv/t8mzKukrSA==" });
        }
    }
}
