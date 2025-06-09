using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromotionService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "promotionSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promotionSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotion_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Promotion_Id = table.Column<int>(type: "int", nullable: false),
                    Product_Category_Id = table.Column<int>(type: "int", nullable: false),
                    Product_Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotion_Details_promotionSales_Promotion_Id",
                        column: x => x.Promotion_Id,
                        principalTable: "promotionSales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_Details_Promotion_Id",
                table: "Promotion_Details",
                column: "Promotion_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotion_Details");

            migrationBuilder.DropTable(
                name: "promotionSales");
        }
    }
}
