using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Web.Migrations
{
    /// <inheritdoc />
    public partial class fixWishListTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_customers_CustomerId",
                table: "WishList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_customers_CustomerId1",
                table: "WishList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_products_ProductId",
                table: "WishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishList",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_ProductId",
                table: "WishList");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "WishList");

            migrationBuilder.RenameTable(
                name: "WishList",
                newName: "wishlist");

            migrationBuilder.RenameColumn(
                name: "CustomerId1",
                table: "wishlist",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "wishlist",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_CustomerId1",
                table: "wishlist",
                newName: "IX_wishlist_product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wishlist",
                table: "wishlist",
                columns: new[] { "customer_id", "product_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_wishlist_customers_customer_id",
                table: "wishlist",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wishlist_products_product_id",
                table: "wishlist",
                column: "product_id",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wishlist_customers_customer_id",
                table: "wishlist");

            migrationBuilder.DropForeignKey(
                name: "FK_wishlist_products_product_id",
                table: "wishlist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_wishlist",
                table: "wishlist");

            migrationBuilder.RenameTable(
                name: "wishlist",
                newName: "WishList");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "WishList",
                newName: "CustomerId1");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "WishList",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_wishlist_product_id",
                table: "WishList",
                newName: "IX_WishList_CustomerId1");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "WishList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishList",
                table: "WishList",
                columns: new[] { "CustomerId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_WishList_ProductId",
                table: "WishList",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_customers_CustomerId",
                table: "WishList",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_customers_CustomerId1",
                table: "WishList",
                column: "CustomerId1",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_products_ProductId",
                table: "WishList",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
