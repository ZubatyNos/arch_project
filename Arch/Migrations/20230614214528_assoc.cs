using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchProject.Migrations
{
    /// <inheritdoc />
    public partial class assoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_FoodItem_FoodId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Store_StoreId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItem_Order_OrderId",
                table: "FoodItem");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodItem_Store_StoreId",
                table: "FoodItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodItem",
                table: "FoodItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "FoodItemId",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "FoodItem",
                newName: "Food");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "CartEntry");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItem_StoreId",
                table: "Food",
                newName: "IX_Food_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodItem_OrderId",
                table: "Food",
                newName: "IX_Food_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_FoodId",
                table: "CartEntry",
                newName: "IX_CartEntry_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartEntry",
                table: "CartEntry",
                columns: new[] { "StoreId", "FoodId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartEntry_Food_FoodId",
                table: "CartEntry",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartEntry_Store_StoreId",
                table: "CartEntry",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Order_OrderId",
                table: "Food",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Store_StoreId",
                table: "Food",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartEntry_Food_FoodId",
                table: "CartEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_CartEntry_Store_StoreId",
                table: "CartEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Order_OrderId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Store_StoreId",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartEntry",
                table: "CartEntry");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "FoodItem");

            migrationBuilder.RenameTable(
                name: "CartEntry",
                newName: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_Food_StoreId",
                table: "FoodItem",
                newName: "IX_FoodItem_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_OrderId",
                table: "FoodItem",
                newName: "IX_FoodItem_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_CartEntry_FoodId",
                table: "Cart",
                newName: "IX_Cart_FoodId");

            migrationBuilder.AddColumn<int>(
                name: "FoodItemId",
                table: "Cart",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodItem",
                table: "FoodItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                columns: new[] { "StoreId", "FoodItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_FoodItem_FoodId",
                table: "Cart",
                column: "FoodId",
                principalTable: "FoodItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Store_StoreId",
                table: "Cart",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItem_Order_OrderId",
                table: "FoodItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItem_Store_StoreId",
                table: "FoodItem",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id");
        }
    }
}
