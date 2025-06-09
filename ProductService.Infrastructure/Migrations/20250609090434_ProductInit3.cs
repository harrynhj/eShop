using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductInit3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variation_Value_Category_Variation_CategoryVariationId",
                table: "Variation_Value");

            migrationBuilder.RenameColumn(
                name: "CategoryVariationId",
                table: "Variation_Value",
                newName: "Variation_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_Variation_Value_CategoryVariationId",
                table: "Variation_Value",
                newName: "IX_Variation_Value_Variation_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Variation_Value_Category_Variation_Variation_Id1",
                table: "Variation_Value",
                column: "Variation_Id1",
                principalTable: "Category_Variation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variation_Value_Category_Variation_Variation_Id1",
                table: "Variation_Value");

            migrationBuilder.RenameColumn(
                name: "Variation_Id1",
                table: "Variation_Value",
                newName: "CategoryVariationId");

            migrationBuilder.RenameIndex(
                name: "IX_Variation_Value_Variation_Id1",
                table: "Variation_Value",
                newName: "IX_Variation_Value_CategoryVariationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Variation_Value_Category_Variation_CategoryVariationId",
                table: "Variation_Value",
                column: "CategoryVariationId",
                principalTable: "Category_Variation",
                principalColumn: "Id");
        }
    }
}
