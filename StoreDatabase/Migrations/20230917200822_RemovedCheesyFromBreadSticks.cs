using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreDatabase.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCheesyFromBreadSticks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ProductName",
                value: "Bread Sticks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ProductName",
                value: "Cheesy Bread Sticks");
        }
    }
}
