using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ShippingInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Person = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipper_Region",
                columns: table => new
                {
                    Region_Id = table.Column<int>(type: "int", nullable: false),
                    Shipper_Id = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipper_Region", x => new { x.Region_Id, x.Shipper_Id });
                    table.ForeignKey(
                        name: "FK_Shipper_Region_Regions_Region_Id",
                        column: x => x.Region_Id,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipper_Region_Shippers_Shipper_Id",
                        column: x => x.Shipper_Id,
                        principalTable: "Shippers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipping_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Shipper_Id = table.Column<int>(type: "int", nullable: false),
                    Shipping_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shipping_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipperId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipping_Details_Shippers_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "Shippers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipper_Region_Shipper_Id",
                table: "Shipper_Region",
                column: "Shipper_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_Details_ShipperId",
                table: "Shipping_Details",
                column: "ShipperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipper_Region");

            migrationBuilder.DropTable(
                name: "Shipping_Details");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Shippers");
        }
    }
}
