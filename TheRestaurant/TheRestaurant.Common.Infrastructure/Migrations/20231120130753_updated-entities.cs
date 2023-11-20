using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MenuItems_MenuItemId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MenuItemId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuItemId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MenuItemId",
                table: "Categories",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MenuItems_MenuItemId",
                table: "Categories",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id");
        }
    }
}
