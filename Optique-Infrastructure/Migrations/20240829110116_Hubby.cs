using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optique_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Hubby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vl",
                table: "Factures");

            migrationBuilder.DropColumn(
                name: "vp",
                table: "Factures");

            migrationBuilder.AddColumn<decimal>(
                name: "Prixmoture",
                table: "Factures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prixmoture",
                table: "Factures");

            migrationBuilder.AddColumn<int>(
                name: "vl",
                table: "Factures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vp",
                table: "Factures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
