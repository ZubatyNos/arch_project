using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArchProject.Migrations
{
    /// <inheritdoc />
    public partial class eqw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StoreFood",
                columns: new[] { "FoodId", "StoreId", "Price" },
                values: new object[,]
                {
                    { 1, 1, 20 },
                    { 2, 1, 30 },
                    { 3, 1, 40 },
                    { 4, 1, 50 },
                    { 5, 1, 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoreFood",
                keyColumns: new[] { "FoodId", "StoreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StoreFood",
                keyColumns: new[] { "FoodId", "StoreId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StoreFood",
                keyColumns: new[] { "FoodId", "StoreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "StoreFood",
                keyColumns: new[] { "FoodId", "StoreId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "StoreFood",
                keyColumns: new[] { "FoodId", "StoreId" },
                keyValues: new object[] { 5, 1 });
        }
    }
}
