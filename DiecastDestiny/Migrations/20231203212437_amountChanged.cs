using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiecastDestiny.Migrations
{
    /// <inheritdoc />
    public partial class amountChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ShoppingCartItems",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ShoppingCartItems",
                newName: "Quantity");
        }
    }
}
