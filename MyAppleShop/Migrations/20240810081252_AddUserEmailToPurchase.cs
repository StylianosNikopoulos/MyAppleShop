using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAppleShop.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEmailToPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "WatchPurchases",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "ProductPurchases",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "WatchPurchases");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "ProductPurchases");
        }
    }
}
