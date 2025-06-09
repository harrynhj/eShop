using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ShippingInit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipping_Details_Shippers_ShipperId",
                table: "Shipping_Details");

            migrationBuilder.DropIndex(
                name: "IX_Shipping_Details_ShipperId",
                table: "Shipping_Details");

            migrationBuilder.DropColumn(
                name: "ShipperId",
                table: "Shipping_Details");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_Details_Shipper_Id",
                table: "Shipping_Details",
                column: "Shipper_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipping_Details_Shippers_Shipper_Id",
                table: "Shipping_Details",
                column: "Shipper_Id",
                principalTable: "Shippers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipping_Details_Shippers_Shipper_Id",
                table: "Shipping_Details");

            migrationBuilder.DropIndex(
                name: "IX_Shipping_Details_Shipper_Id",
                table: "Shipping_Details");

            migrationBuilder.AddColumn<int>(
                name: "ShipperId",
                table: "Shipping_Details",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_Details_ShipperId",
                table: "Shipping_Details",
                column: "ShipperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipping_Details_Shippers_ShipperId",
                table: "Shipping_Details",
                column: "ShipperId",
                principalTable: "Shippers",
                principalColumn: "Id");
        }
    }
}
