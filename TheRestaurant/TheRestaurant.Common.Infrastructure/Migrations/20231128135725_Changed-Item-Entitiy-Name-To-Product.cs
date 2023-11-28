using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedItemEntitiyNameToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Items_MenuItemId",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemAllergies_Items_MenuItemId",
                table: "MenuItemAllergies");

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "MenuItemAllergies",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemAllergies_MenuItemId",
                table: "MenuItemAllergies",
                newName: "IX_MenuItemAllergies_ProductId");

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "MenuCategories",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuCategories_MenuItemId",
                table: "MenuCategories",
                newName: "IX_MenuCategories_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategories_Items_ProductId",
                table: "MenuCategories",
                column: "ProductId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemAllergies_Items_ProductId",
                table: "MenuItemAllergies",
                column: "ProductId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Items_ProductId",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemAllergies_Items_ProductId",
                table: "MenuItemAllergies");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "MenuItemAllergies",
                newName: "MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemAllergies_ProductId",
                table: "MenuItemAllergies",
                newName: "IX_MenuItemAllergies_MenuItemId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "MenuCategories",
                newName: "MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuCategories_ProductId",
                table: "MenuCategories",
                newName: "IX_MenuCategories_MenuItemId");

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
    }
}
