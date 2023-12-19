using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeedPriceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 16, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 11, 0, 24, 543, DateTimeKind.Local).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 99.0, 88.390000000000001 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 119.0, 106.25 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 139.0, 124.11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 99.0, 88.390000000000001 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 59.0, 52.68 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 79.0, 70.540000000000006 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 129.0, 115.18000000000001 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 139.0, 124.11 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 169.0, 150.88999999999999 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 69.0, 61.609999999999999 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 25.0, 22.32 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 25.0, 22.32 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 49.0, 39.200000000000003 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 49.0, 39.200000000000003 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 129.0, 103.2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 259.0, 244.34 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 449.0, 359.19999999999999 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 199.0, 159.19999999999999 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 199.0, 159.19999999999999 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 16, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 9, 38, 36, 681, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 88.480000000000004, 79.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 110.88, 99.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 144.47999999999999, 129.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 99.680000000000007, 89.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 54.880000000000003, 49.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 77.280000000000001, 69.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 122.08, 109.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 133.28, 119.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 166.88, 149.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 66.079999999999998, 59.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 22.399999999999999, 20.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 22.399999999999999, 20.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 50.0, 40.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 75.0, 60.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 150.0, 120.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 104.94, 99.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 562.5, 450.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 250.0, 200.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Price", "PriceBeforeVAT" },
                values: new object[] { 250.0, 200.0 });
        }
    }
}
