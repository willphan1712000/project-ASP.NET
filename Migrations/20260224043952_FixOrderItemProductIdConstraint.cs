using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Web.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderItemProductIdConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_orderItems_ProductId",
                table: "orderItems");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ProductId",
                table: "orderItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_orderItems_ProductId",
                table: "orderItems");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ProductId",
                table: "orderItems",
                column: "ProductId",
                unique: true);
        }
    }
}
