using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product_Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent_Category_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_Product_Category_Parent_Category_Id",
                        column: x => x.Parent_Category_Id,
                        principalTable: "Product_Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category_Variation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Variation_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Variation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Variation_Product_Category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Product_Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Product_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Product_Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Variation_Value",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariationId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryVariationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variation_Value", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variation_Value_Category_Variation_CategoryVariationId",
                        column: x => x.CategoryVariationId,
                        principalTable: "Category_Variation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product_variation_values",
                columns: table => new
                {
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Variation_value_id = table.Column<int>(type: "int", nullable: false),
                    Product_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_variation_values", x => new { x.Product_Id, x.Variation_value_id });
                    table.ForeignKey(
                        name: "FK_Product_variation_values_Products_Product_Id1",
                        column: x => x.Product_Id1,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_variation_values_Variation_Value_Variation_value_id",
                        column: x => x.Variation_value_id,
                        principalTable: "Variation_Value",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Variation_Category_Id",
                table: "Category_Variation",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Parent_Category_Id",
                table: "Product_Category",
                column: "Parent_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_variation_values_Product_Id1",
                table: "Product_variation_values",
                column: "Product_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_variation_values_Variation_value_id",
                table: "Product_variation_values",
                column: "Variation_value_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Variation_Value_CategoryVariationId",
                table: "Variation_Value",
                column: "CategoryVariationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_variation_values");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Variation_Value");

            migrationBuilder.DropTable(
                name: "Category_Variation");

            migrationBuilder.DropTable(
                name: "Product_Category");
        }
    }
}
