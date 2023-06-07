using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArchProject.Migrations
{
    /// <inheritdoc />
    public partial class column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreFoodItem_FoodItem_FoodItemId",
                table: "StoreFoodItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreFoodItem",
                table: "StoreFoodItem");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "StoreFoodItem");

            migrationBuilder.AlterColumn<int>(
                name: "FoodItemId",
                table: "StoreFoodItem",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FoodItem",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FoodItem",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreFoodItem",
                table: "StoreFoodItem",
                columns: new[] { "StoreId", "FoodItemId" });

            migrationBuilder.InsertData(
                table: "FoodItem",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Burger with a kick", "Molotov burger" },
                    { 2, "Lame burger", "Vegan burger" },
                    { 3, "Just fries, man", "Fries" },
                    { 4, ":)))", "Coke" },
                    { 5, "Best one", "Hasbulla burger" }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "ClosingTime", "Name", "OpeningTime" },
                values: new object[] { 2, new TimeSpan(0, 23, 0, 0, 0), "Tuniaky", new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "StoreFoodItem",
                columns: new[] { "FoodItemId", "StoreId", "Price" },
                values: new object[,]
                {
                    { 1, 1, 10m },
                    { 2, 1, 10m },
                    { 3, 1, 10m },
                    { 4, 1, 10m },
                    { 5, 1, 10m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreFoodItem_FoodItem_FoodItemId",
                table: "StoreFoodItem",
                column: "FoodItemId",
                principalTable: "FoodItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreFoodItem_FoodItem_FoodItemId",
                table: "StoreFoodItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreFoodItem",
                table: "StoreFoodItem");

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "StoreFoodItem",
                keyColumns: new[] { "FoodItemId", "StoreId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FoodItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "FoodItemId",
                table: "StoreFoodItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "StoreFoodItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FoodItem",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FoodItem",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreFoodItem",
                table: "StoreFoodItem",
                columns: new[] { "StoreId", "ItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreFoodItem_FoodItem_FoodItemId",
                table: "StoreFoodItem",
                column: "FoodItemId",
                principalTable: "FoodItem",
                principalColumn: "Id");
        }
    }
}
