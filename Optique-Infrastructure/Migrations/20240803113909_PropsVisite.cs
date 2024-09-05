using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optique_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PropsVisite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Avance",
                table: "Visites",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Remise",
                table: "Visites",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Reste",
                table: "Visites",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Visites",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avance",
                table: "Visites");

            migrationBuilder.DropColumn(
                name: "Remise",
                table: "Visites");

            migrationBuilder.DropColumn(
                name: "Reste",
                table: "Visites");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Visites");
        }
    }
}
