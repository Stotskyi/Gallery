using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryAPI.DAL.Entities
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 13, 17, 42, 13, 968, DateTimeKind.Utc).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86e6f197-1fcc-45ca-9da9-0c43ebafc1fd", "AQAAAAIAAYagAAAAEKOWN22pdd1QjwLdawla8Ub/pJVKj+K1SsLXur58xKdorP5fKj16fVBeiwNskIk3cA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 13, 13, 31, 52, 903, DateTimeKind.Utc).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9db77539-ae1f-4bc5-92ac-596c43659ea2", "AQAAAAIAAYagAAAAEE13hMoTkASCJc+zgdXCYU6p1eZKAarghoQ2IiN7MHWM/vtB33w5MtHIYwMyHxdWgg==" });
        }
    }
}
