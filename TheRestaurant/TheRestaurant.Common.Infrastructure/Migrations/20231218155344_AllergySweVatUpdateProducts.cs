using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AllergySweVatUpdateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Jordnötter");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Skaldjur");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Mjölk");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Ägg");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Fisk");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Nötter");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Vete");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Soja");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Sesamfrö ");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Sulfit");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 14, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8838));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 16, 16, 53, 43, 930, DateTimeKind.Local).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 88.480000000000004);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 110.88);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 144.47999999999999);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 99.680000000000007);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 54.880000000000003);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 77.280000000000001);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 122.08);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 133.28);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 166.88);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Price",
                value: 66.079999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Price",
                value: 22.399999999999999);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Price",
                value: 22.399999999999999);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Price", "VATId" },
                values: new object[] { 150.0, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "Price",
                value: 104.94);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Price", "VATId" },
                values: new object[] { 562.5, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Price", "VATId" },
                values: new object[] { 250.0, 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Price", "VATId" },
                values: new object[] { 250.0, 4 });

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
                value: "Alkohol");

            migrationBuilder.InsertData(
                table: "VATs",
                columns: new[] { "Id", "Adjustment", "IsDeleted", "Name" },
                values: new object[] { 4, 1.25, false, "Produkter/Kläder" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Peanuts");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Shellfish");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Milk");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Eggs");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Fish");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Tree nuts");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Wheat");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Soy");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Sesame");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Sulfites");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(905));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 14, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(926));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(928));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 16, 16, 6, 22, 537, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 88.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 111.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 144.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 55.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 77.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 122.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 133.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 167.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Price",
                value: 66.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Price",
                value: 22.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Price",
                value: 22.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Price", "VATId" },
                values: new object[] { 127.0, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "Price",
                value: 105.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Price", "VATId" },
                values: new object[] { 477.0, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Price", "VATId" },
                values: new object[] { 212.0, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Price", "VATId" },
                values: new object[] { 212.0, 2 });

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
