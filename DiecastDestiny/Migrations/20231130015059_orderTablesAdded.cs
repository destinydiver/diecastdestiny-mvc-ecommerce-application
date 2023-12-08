using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiecastDestiny.Migrations
{
    /// <inheritdoc />
    public partial class orderTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "OrderItems",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderItems",
                newName: "Amount");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ShoppingCartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
