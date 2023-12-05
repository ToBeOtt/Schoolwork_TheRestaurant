using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class orderentityupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderRows_OrderRowId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "EmployeeOrders");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderRowId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderRowId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderRows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRows_ProductId",
                table: "OrderRows",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Products_ProductId",
                table: "OrderRows",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_EmployeeId",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Products_ProductId",
                table: "OrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_EmployeeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderRows_ProductId",
                table: "OrderRows");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderRows");

            migrationBuilder.AddColumn<int>(
                name: "OrderRowId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeOrders_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderRowId",
                table: "Products",
                column: "OrderRowId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOrders_EmployeeId",
                table: "EmployeeOrders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOrders_OrderId",
                table: "EmployeeOrders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderRows_OrderRowId",
                table: "Products",
                column: "OrderRowId",
                principalTable: "OrderRows",
                principalColumn: "Id");
        }
    }
}
