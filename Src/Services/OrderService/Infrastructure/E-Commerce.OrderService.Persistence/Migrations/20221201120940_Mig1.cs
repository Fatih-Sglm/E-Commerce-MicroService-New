using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.OrderService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "ordering",
                table: "buyers",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                schema: "ordering",
                table: "order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "ordering",
                table: "buyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                schema: "ordering",
                table: "buyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                schema: "ordering",
                table: "order");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "ordering",
                table: "buyers");

            migrationBuilder.DropColumn(
                name: "Fullname",
                schema: "ordering",
                table: "buyers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "ordering",
                table: "buyers",
                newName: "Name");
        }
    }
}
