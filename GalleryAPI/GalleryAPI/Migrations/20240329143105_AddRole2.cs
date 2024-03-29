using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 29, 14, 31, 4, 795, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1eb29104-1355-402c-8503-ab487660033f", "AQAAAAIAAYagAAAAEAyxpuHuhZVxBywNDHudcwkF9Qu2Jhfa0lhpkcDGKt7TeRt0oeto1uv/t8mzKukrSA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 29, 14, 29, 32, 968, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6d2dc54-93bc-4747-91b3-6e7531c0d0c8", "AQAAAAIAAYagAAAAECTLZJuGsZ44aIDJgcBmK+noHVyOeYdvv30j3Z+LR/HJ8X0bhoq3dN5bIUnXWbBoLg==" });
        }
    }
}
