using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedtshirts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5197));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 16, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 12, 1, 17, 610, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "Size",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Name", "Size" },
                values: new object[] { "Elegant svart T-shirt i högkvalitativt material", "Svart T-shirt", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IsDeleted", "IsFoodItem", "MenuPhoto", "Name", "Price", "PriceBeforeVAT", "Size", "VATId" },
                values: new object[,]
                {
                    { 20, "Elegant svart T-shirt i högkvalitativt material", false, false, null, "Svart T-shirt", 250.0, 200.0, 2, 4 },
                    { 21, "Elegant svart T-shirt i högkvalitativt material", false, false, null, "Svart T-shirt", 250.0, 200.0, 3, 4 },
                    { 22, "Elegant svart T-shirt i högkvalitativt material", false, false, null, "Svart T-shirt", 250.0, 200.0, 4, 4 },
                    { 23, "Klassisk vit T-shirt i mjukt och bekvämt material", false, false, null, "Vit T-shirt", 250.0, 200.0, 0, 4 },
                    { 24, "Klassisk vit T-shirt i mjukt och bekvämt material", false, false, null, "Vit T-shirt", 250.0, 200.0, 1, 4 },
                    { 25, "Klassisk vit T-shirt i mjukt och bekvämt material", false, false, null, "Vit T-shirt", 250.0, 200.0, 2, 4 },
                    { 26, "Klassisk vit T-shirt i mjukt och bekvämt material", false, false, null, "Vit T-shirt", 250.0, 200.0, 3, 4 },
                    { 27, "Klassisk vit T-shirt i mjukt och bekvämt material", false, false, null, "Vit T-shirt", 250.0, 200.0, 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8738));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 16, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 19, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 9, 31, 22, 76, DateTimeKind.Local).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "Size",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Name", "Size" },
                values: new object[] { "Klassisk vit T-shirt i mjukt och bekvämt material", "Vit T-shirt", null });
        }
    }
}
