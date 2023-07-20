using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.OrderService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expiration",
                schema: "ordering",
                table: "paymentmethods");

            migrationBuilder.AddColumn<string>(
                name: "ExpirationMonth",
                schema: "ordering",
                table: "paymentmethods",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpirationYear",
                schema: "ordering",
                table: "paymentmethods",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationMonth",
                schema: "ordering",
                table: "paymentmethods");

            migrationBuilder.DropColumn(
                name: "ExpirationYear",
                schema: "ordering",
                table: "paymentmethods");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expiration",
                schema: "ordering",
                table: "paymentmethods",
                type: "datetime2",
                maxLength: 25,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
