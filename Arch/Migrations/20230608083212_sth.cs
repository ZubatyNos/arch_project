using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchProject.Migrations
{
    /// <inheritdoc />
    public partial class sth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderStoreFoodItem",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderStoreFoodItem");
        }
    }
}
