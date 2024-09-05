using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optique_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Prs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "Ventes",
                newName: "Profit");

            migrationBuilder.RenameColumn(
                name: "DateVente",
                table: "Ventes",
                newName: "VenteDate");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Ventes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Ventes");

            migrationBuilder.RenameColumn(
                name: "VenteDate",
                table: "Ventes",
                newName: "DateVente");

            migrationBuilder.RenameColumn(
                name: "Profit",
                table: "Ventes",
                newName: "Montant");
        }
    }
}
