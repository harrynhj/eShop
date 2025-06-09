using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductInit4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variation_Value_Category_Variation_Variation_Id1",
                table: "Variation_Value");

            migrationBuilder.DropIndex(
                name: "IX_Variation_Value_Variation_Id1",
                table: "Variation_Value");

            migrationBuilder.DropColumn(
                name: "Variation_Id1",
                table: "Variation_Value");

            migrationBuilder.CreateIndex(
                name: "IX_Variation_Value_Variation_Id",
                table: "Variation_Value",
                column: "Variation_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Variation_Value_Category_Variation_Variation_Id",
                table: "Variation_Value",
                column: "Variation_Id",
                principalTable: "Category_Variation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variation_Value_Category_Variation_Variation_Id",
                table: "Variation_Value");

            migrationBuilder.DropIndex(
                name: "IX_Variation_Value_Variation_Id",
                table: "Variation_Value");

            migrationBuilder.AddColumn<int>(
                name: "Variation_Id1",
                table: "Variation_Value",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Variation_Value_Variation_Id1",
                table: "Variation_Value",
                column: "Variation_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Variation_Value_Category_Variation_Variation_Id1",
                table: "Variation_Value",
                column: "Variation_Id1",
                principalTable: "Category_Variation",
                principalColumn: "Id");
        }
    }
}
