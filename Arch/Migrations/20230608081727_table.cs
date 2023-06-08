using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchProject.Migrations
{
    /// <inheritdoc />
    public partial class table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderStoreFoodItem",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    StoreId = table.Column<int>(type: "integer", nullable: false),
                    FoodItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStoreFoodItem", x => new { x.OrderId, x.StoreId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_OrderStoreFoodItem_FoodItem_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStoreFoodItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStoreFoodItem_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderStoreFoodItem_FoodItemId",
                table: "OrderStoreFoodItem",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStoreFoodItem_StoreId",
                table: "OrderStoreFoodItem",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStoreFoodItem");
        }
    }
}
