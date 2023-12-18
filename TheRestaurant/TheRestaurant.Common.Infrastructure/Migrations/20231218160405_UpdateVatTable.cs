using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVatTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 14, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5962));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 16, 17, 4, 5, 199, DateTimeKind.Local).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mat");

            migrationBuilder.UpdateData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Böcker");

            migrationBuilder.UpdateData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Aklohol");

            migrationBuilder.InsertData(
                table: "VATs",
                columns: new[] { "Id", "Adjustment", "IsDeleted", "Name" },
                values: new object[] { 4, 1.25, false, "Varor/Kläder" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 14, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 16, 16, 59, 18, 835, DateTimeKind.Local).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Food");

            migrationBuilder.UpdateData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Merchandise");

            migrationBuilder.UpdateData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Alcohol");
        }
    }
}
