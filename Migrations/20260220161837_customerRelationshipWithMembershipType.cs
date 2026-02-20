using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Web.Migrations
{
    /// <inheritdoc />
    public partial class customerRelationshipWithMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembershipTypeId",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_customers_MembershipTypeId",
                table: "customers",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_membershipType_MembershipTypeId",
                table: "customers",
                column: "MembershipTypeId",
                principalTable: "membershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_membershipType_MembershipTypeId",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_MembershipTypeId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "customers");
        }
    }
}
