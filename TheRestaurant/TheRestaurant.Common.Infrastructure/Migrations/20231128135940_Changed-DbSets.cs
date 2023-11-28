using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_OrderRows_OrderRowId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Categories_CategoriesId",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategories_Items_ProductId",
                table: "MenuCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemAllergies_Allergies_AllergyId",
                table: "MenuItemAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemAllergies_Items_ProductId",
                table: "MenuItemAllergies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemAllergies",
                table: "MenuItemAllergies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuCategories",
                table: "MenuCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "MenuItemAllergies",
                newName: "ProductAllergies");

            migrationBuilder.RenameTable(
                name: "MenuCategories",
                newName: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemAllergies_ProductId",
                table: "ProductAllergies",
                newName: "IX_ProductAllergies_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemAllergies_AllergyId",
                table: "ProductAllergies",
                newName: "IX_ProductAllergies_AllergyId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuCategories_ProductId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuCategories_CategoriesId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_OrderRowId",
                table: "Products",
                newName: "IX_Products_OrderRowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAllergies",
                table: "ProductAllergies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAllergies_Allergies_AllergyId",
                table: "ProductAllergies",
                column: "AllergyId",
                principalTable: "Allergies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAllergies_Products_ProductId",
                table: "ProductAllergies",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Categories_CategoriesId",
                table: "ProductCategories",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderRows_OrderRowId",
                table: "Products",
                column: "OrderRowId",
                principalTable: "OrderRows",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAllergies_Allergies_AllergyId",
                table: "ProductAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAllergies_Products_ProductId",
                table: "ProductAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Categories_CategoriesId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderRows_OrderRowId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAllergies",
                table: "ProductAllergies");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "MenuCategories");

            migrationBuilder.RenameTable(
                name: "ProductAllergies",
                newName: "MenuItemAllergies");

            migrationBuilder.RenameIndex(
                name: "IX_Products_OrderRowId",
                table: "Items",
                newName: "IX_Items_OrderRowId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_ProductId",
                table: "MenuCategories",
                newName: "IX_MenuCategories_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_CategoriesId",
                table: "MenuCategories",
                newName: "IX_MenuCategories_CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAllergies_ProductId",
                table: "MenuItemAllergies",
                newName: "IX_MenuItemAllergies_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAllergies_AllergyId",
                table: "MenuItemAllergies",
                newName: "IX_MenuItemAllergies_AllergyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuCategories",
                table: "MenuCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemAllergies",
                table: "MenuItemAllergies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_OrderRows_OrderRowId",
                table: "Items",
                column: "OrderRowId",
                principalTable: "OrderRows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategories_Categories_CategoriesId",
                table: "MenuCategories",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategories_Items_ProductId",
                table: "MenuCategories",
                column: "ProductId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemAllergies_Allergies_AllergyId",
                table: "MenuItemAllergies",
                column: "AllergyId",
                principalTable: "Allergies",
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
    }
}
