using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRestaurant.Common.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedcategoryfieldstosingular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Categories_CategoriesId",
                table: "ProductCategories");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "ProductCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_CategoriesId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ProductCategories",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Categories_CategoriesId",
                table: "ProductCategories",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
