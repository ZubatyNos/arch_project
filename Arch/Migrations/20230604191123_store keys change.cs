using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchProject.Migrations
{
    /// <inheritdoc />
    public partial class storekeyschange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "openingTime",
                table: "Store",
                newName: "OpeningTime");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Store",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "closingTime",
                table: "Store",
                newName: "ClosingTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpeningTime",
                table: "Store",
                newName: "openingTime");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Store",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ClosingTime",
                table: "Store",
                newName: "closingTime");
        }
    }
}
