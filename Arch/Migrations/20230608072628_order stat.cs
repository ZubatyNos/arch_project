using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArchProject.Migrations
{
    /// <inheritdoc />
    public partial class orderstat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "StoreFoodItem",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreFoodItem_Order_OrderId",
                table: "StoreFoodItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_StoreFoodItem_OrderId",
                table: "StoreFoodItem");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "StoreFoodItem");
        }
    }
}
