using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Web.Migrations
{
    /// <inheritdoc />
    public partial class addMorePropertiesToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profile_customers_Customer_id",
                table: "profile");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_id",
                table: "profile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "customers",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "customers",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_profile_customers_Customer_id",
                table: "profile",
                column: "Customer_id",
                principalTable: "customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profile_customers_Customer_id",
                table: "profile");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "customers");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_id",
                table: "profile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_profile_customers_Customer_id",
                table: "profile",
                column: "Customer_id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
