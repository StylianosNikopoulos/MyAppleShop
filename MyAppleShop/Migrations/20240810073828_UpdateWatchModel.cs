using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAppleShop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWatchModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "watches",
                keyColumn: "PriceId",
                keyValue: null,
                column: "PriceId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PriceId",
                table: "watches",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PriceId",
                table: "watches",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
