using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllergiesToSwe : Migration
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
                value: "Sesamfrö");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Sulfiter");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
