using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbSetItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_MenuItems_MenuItemId",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemAllergies_MenuItems_MenuItemId",
                table: "MenuItemAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_OrderRows_OrderRowId",
                table: "MenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems");

            migrationBuilder.RenameTable(
                name: "MenuItems",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_OrderRowId",
                table: "Items",
                newName: "IX_Items_OrderRowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_OrderRows_OrderRowId",
                table: "Items",
                column: "OrderRowId",
                principalTable: "OrderRows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategories_Items_MenuItemId",
                table: "MenuCategories",
                column: "MenuItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemAllergies_Items_MenuItemId",
                table: "MenuItemAllergies",
                column: "MenuItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_OrderRows_OrderRowId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Items_MenuItemId",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemAllergies_Items_MenuItemId",
                table: "MenuItemAllergies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "MenuItems");

            migrationBuilder.RenameIndex(
                name: "IX_Items_OrderRowId",
                table: "MenuItems",
                newName: "IX_MenuItems_OrderRowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategories_MenuItems_MenuItemId",
                table: "MenuCategories",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemAllergies_MenuItems_MenuItemId",
                table: "MenuItemAllergies",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_OrderRows_OrderRowId",
                table: "MenuItems",
                column: "OrderRowId",
                principalTable: "OrderRows",
                principalColumn: "Id");
        }
    }
}
