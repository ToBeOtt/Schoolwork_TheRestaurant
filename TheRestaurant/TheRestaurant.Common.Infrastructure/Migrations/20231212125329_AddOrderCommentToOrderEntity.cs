using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderCommentToOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_VAT_VATId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VAT",
                table: "VAT");

            migrationBuilder.RenameTable(
                name: "VAT",
                newName: "VATs");

            migrationBuilder.AddColumn<string>(
                name: "OrderComment",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VATs",
                table: "VATs",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 12, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9752) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 11, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9795) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 12, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9805) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 12, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9807) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 11, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9817) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 9, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9812) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 8, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9815) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 12, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9802) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 11, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9820) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 11, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "OrderComment", "OrderDate" },
                values: new object[] { null, new DateTime(2023, 12, 10, 13, 53, 29, 264, DateTimeKind.Local).AddTicks(9809) });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VATs_VATId",
                table: "Products",
                column: "VATId",
                principalTable: "VATs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_VATs_VATId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VATs",
                table: "VATs");

            migrationBuilder.DropColumn(
                name: "OrderComment",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "VATs",
                newName: "VAT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VAT",
                table: "VAT",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 12, 10, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 12, 10, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7377));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 12, 8, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                column: "OrderDate",
                value: new DateTime(2023, 12, 7, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 31,
                column: "OrderDate",
                value: new DateTime(2023, 12, 11, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 32,
                column: "OrderDate",
                value: new DateTime(2023, 12, 10, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 33,
                column: "OrderDate",
                value: new DateTime(2023, 12, 10, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 34,
                column: "OrderDate",
                value: new DateTime(2023, 12, 9, 8, 58, 26, 911, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_VAT_VATId",
                table: "Products",
                column: "VATId",
                principalTable: "VAT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
