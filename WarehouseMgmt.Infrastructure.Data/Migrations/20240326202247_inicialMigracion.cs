using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMgmt.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class inicialMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 26, 14, 22, 47, 102, DateTimeKind.Local).AddTicks(4169), "$2a$10$Hr6dS6vUaPFMoY.N5Z273uRwTa2./SuQMn4sTvd/35ILIqBfez/vK", new DateTime(2024, 3, 26, 14, 22, 47, 102, DateTimeKind.Local).AddTicks(4183) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 26, 14, 22, 47, 102, DateTimeKind.Local).AddTicks(4195), "$2a$10$sM50m2/oAu5oo/EXWKpXGu0AbDEMzNjAqfD7K32XbjYBt/p9TGt5a", new DateTime(2024, 3, 26, 14, 22, 47, 102, DateTimeKind.Local).AddTicks(4195) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 25, 10, 21, 36, 628, DateTimeKind.Local).AddTicks(9811), "$2a$10$lM9AgGV9ejUiol6uhwmfQOX4TvsY1oBBG89hjB8ltYlTWCf01ZOFq", new DateTime(2024, 3, 25, 10, 21, 36, 628, DateTimeKind.Local).AddTicks(9823) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 3, 25, 10, 21, 36, 628, DateTimeKind.Local).AddTicks(9836), "$2a$10$po3HswzE05XIO5WTZSDEy.HI.jAqeRDD5/ZJIkyJw1zffj0QmFloC", new DateTime(2024, 3, 25, 10, 21, 36, 628, DateTimeKind.Local).AddTicks(9836) });
        }
    }
}
