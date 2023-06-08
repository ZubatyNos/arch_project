using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchProject.Migrations
{
    /// <inheritdoc />
    public partial class jointablefr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreFoodItem_Order_OrderId",
                table: "StoreFoodItem");

            migrationBuilder.DropIndex(
                name: "IX_StoreFoodItem_OrderId",
                table: "StoreFoodItem");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "StoreFoodItem");

            migrationBuilder.AddColumn<int>(
                name: "StoreFoodItemFoodItemId",
                table: "Order",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreFoodItemStoreId",
                table: "Order",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreFoodItemStoreId_StoreFoodItemFoodItemId",
                table: "Order",
                columns: new[] { "StoreFoodItemStoreId", "StoreFoodItemFoodItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_StoreFoodItem_StoreFoodItemStoreId_StoreFoodItemFoodI~",
                table: "Order",
                columns: new[] { "StoreFoodItemStoreId", "StoreFoodItemFoodItemId" },
                principalTable: "StoreFoodItem",
                principalColumns: new[] { "StoreId", "FoodItemId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_StoreFoodItem_StoreFoodItemStoreId_StoreFoodItemFoodI~",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_StoreFoodItemStoreId_StoreFoodItemFoodItemId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StoreFoodItemFoodItemId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StoreFoodItemStoreId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "StoreFoodItem",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "OrderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "OrderId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_StoreFoodItem_OrderId",
                table: "StoreFoodItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreFoodItem_Order_OrderId",
                table: "StoreFoodItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
