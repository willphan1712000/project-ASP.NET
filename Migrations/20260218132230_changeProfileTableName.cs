using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Web.Migrations
{
    /// <inheritdoc />
    public partial class changeProfileTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_customers_Customer_id",
                table: "Profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "profile");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_Customer_id",
                table: "profile",
                newName: "IX_profile_Customer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_profile",
                table: "profile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_profile_customers_Customer_id",
                table: "profile",
                column: "Customer_id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profile_customers_Customer_id",
                table: "profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_profile",
                table: "profile");

            migrationBuilder.RenameTable(
                name: "profile",
                newName: "Profile");

            migrationBuilder.RenameIndex(
                name: "IX_profile_Customer_id",
                table: "Profile",
                newName: "IX_Profile_Customer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_customers_Customer_id",
                table: "Profile",
                column: "Customer_id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
