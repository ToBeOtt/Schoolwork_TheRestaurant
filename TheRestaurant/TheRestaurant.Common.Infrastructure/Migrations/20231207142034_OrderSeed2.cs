using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 7, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 6, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "EmployeeId", "OrderDate", "OrderStatusId" },
                values: new object[,]
                {
                    { 4, null, new DateTime(2023, 12, 7, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3767), 1 },
                    { 5, null, new DateTime(2023, 12, 7, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3769), 1 },
                    { 6, null, new DateTime(2023, 12, 6, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3780), 5 },
                    { 10, null, new DateTime(2023, 12, 4, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3776), 3 },
                    { 11, null, new DateTime(2023, 12, 3, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3778), 4 },
                    { 31, null, new DateTime(2023, 12, 7, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3761), 1 },
                    { 32, null, new DateTime(2023, 12, 6, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3783), 2 },
                    { 33, null, new DateTime(2023, 12, 6, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3786), 5 },
                    { 34, null, new DateTime(2023, 12, 5, 15, 20, 33, 876, DateTimeKind.Local).AddTicks(3772), 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderRows",
                columns: new[] { "Id", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 16, 31, 1 },
                    { 17, 31, 3 },
                    { 18, 4, 2 },
                    { 19, 4, 5 },
                    { 20, 5, 4 },
                    { 21, 6, 6 },
                    { 22, 6, 7 },
                    { 23, 32, 8 },
                    { 24, 32, 9 },
                    { 25, 33, 10 },
                    { 26, 34, 1 },
                    { 27, 10, 3 },
                    { 28, 11, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 7, 11, 13, 43, 546, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 6, 11, 13, 43, 546, DateTimeKind.Local).AddTicks(268));
        }
    }
}
