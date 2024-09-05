using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optique_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "Produits",
                newName: "PriceForSale");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Produits",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Produits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Produits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Produits");

            migrationBuilder.RenameColumn(
                name: "PriceForSale",
                table: "Produits",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Produits",
                newName: "Nom");
        }
    }
}
