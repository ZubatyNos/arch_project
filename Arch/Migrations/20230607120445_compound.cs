using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchProject.Migrations
{
    /// <inheritdoc />
    public partial class compound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "Price",
                value: 20m);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "Price",
                value: 30m);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "Price",
                value: 40m);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "Price",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "Price",
                value: 60m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "Price",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "Price",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "Price",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "Price",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "Price",
                value: 10m);
        }
    }
}
