using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductInit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_variation_values_Products_Product_Id1",
                table: "Product_variation_values");

            migrationBuilder.DropIndex(
                name: "IX_Product_variation_values_Product_Id1",
                table: "Product_variation_values");

            migrationBuilder.DropColumn(
                name: "Product_Id1",
                table: "Product_variation_values");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_variation_values_Products_Product_Id",
                table: "Product_variation_values",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_variation_values_Products_Product_Id",
                table: "Product_variation_values");

            migrationBuilder.AddColumn<int>(
                name: "Product_Id1",
                table: "Product_variation_values",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_variation_values_Product_Id1",
                table: "Product_variation_values",
                column: "Product_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_variation_values_Products_Product_Id1",
                table: "Product_variation_values",
                column: "Product_Id1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
