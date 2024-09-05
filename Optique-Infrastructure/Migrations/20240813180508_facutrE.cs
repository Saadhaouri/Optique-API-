using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optique_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class facutrE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factures_Ventes_VenteId",
                table: "Factures");

            migrationBuilder.DropColumn(
                name: "Montant",
                table: "Factures");

            migrationBuilder.RenameColumn(
                name: "VenteId",
                table: "Factures",
                newName: "VisiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Factures_VenteId",
                table: "Factures",
                newName: "IX_Factures_VisiteId");

            migrationBuilder.AddColumn<string>(
                name: "NFacture",
                table: "Factures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_Visites_VisiteId",
                table: "Factures",
                column: "VisiteId",
                principalTable: "Visites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factures_Visites_VisiteId",
                table: "Factures");

            migrationBuilder.DropColumn(
                name: "NFacture",
                table: "Factures");

            migrationBuilder.RenameColumn(
                name: "VisiteId",
                table: "Factures",
                newName: "VenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Factures_VisiteId",
                table: "Factures",
                newName: "IX_Factures_VenteId");

            migrationBuilder.AddColumn<decimal>(
                name: "Montant",
                table: "Factures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Factures_Ventes_VenteId",
                table: "Factures",
                column: "VenteId",
                principalTable: "Ventes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
