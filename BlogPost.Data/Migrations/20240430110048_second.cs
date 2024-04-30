using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPost.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EmailIsVerified", "PhoneIsVerified" },
                values: new object[] { new DateTime(2024, 4, 30, 11, 0, 46, 695, DateTimeKind.Utc).AddTicks(4866), true, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EmailIsVerified", "PhoneIsVerified" },
                values: new object[] { new DateTime(2024, 4, 29, 11, 9, 30, 975, DateTimeKind.Utc).AddTicks(1405), false, false });
        }
    }
}
