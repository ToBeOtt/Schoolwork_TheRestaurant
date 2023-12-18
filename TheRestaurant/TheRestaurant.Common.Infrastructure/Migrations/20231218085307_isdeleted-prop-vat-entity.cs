using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class isdeletedpropvatentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VATs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2859));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2873));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 14, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 18, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 17, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 16, 9, 53, 7, 371, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "VATs",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VATs");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 14, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 14, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 12, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 15, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 14, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 14, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 13, 9, 52, 19, 761, DateTimeKind.Local).AddTicks(7831));
        }
    }
}
