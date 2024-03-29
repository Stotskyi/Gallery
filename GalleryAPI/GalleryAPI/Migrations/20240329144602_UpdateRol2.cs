using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRol2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "70f3005c-d645-4d5b-b0d4-34f97238f60f", "ANDRII.STOTSKYI.U@GMAIL.COM", "STOKOVYI", "AQAAAAIAAYagAAAAEBWVjqLWDLWIjQHsRYEEyUZ/W0kjbCPCwlcJzFh5Ms6DF+DcrmRxb8tfqZkT2FHSGw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 29, 14, 42, 6, 64, DateTimeKind.Utc).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "dd2bb4aa-168b-4989-896b-4bc307e36e43", null, null, "AQAAAAIAAYagAAAAEAjSwgt+QsOwV7Z6BSuTMwCbK4tZJcnDZvc56bWE/uzRo8eYE2n5aD4aMblNgIFL+g==" });
        }
    }
}
