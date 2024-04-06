using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 3, 13, 12, 22, 213, DateTimeKind.Utc).AddTicks(822));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 3, "3", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d1c1b79-07e4-4119-a7a7-122e20be02b7", "AQAAAAIAAYagAAAAEMR8Z9mvfgB8hHLZUkJHlSRq7O+AYUTq8BkzxLhMSzjnetQz77tdOVqZ4RxwJFYQHw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 29, 14, 46, 1, 363, DateTimeKind.Utc).AddTicks(26));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "70f3005c-d645-4d5b-b0d4-34f97238f60f", "AQAAAAIAAYagAAAAEBWVjqLWDLWIjQHsRYEEyUZ/W0kjbCPCwlcJzFh5Ms6DF+DcrmRxb8tfqZkT2FHSGw==" });
        }
    }
}
