using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optique_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class vLprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "verre",
                table: "Visites",
                newName: "VerreOS");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceOD",
                table: "Visites",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceOS",
                table: "Visites",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "VerreOD",
                table: "Visites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceOD",
                table: "Visites");

            migrationBuilder.DropColumn(
                name: "PriceOS",
                table: "Visites");

            migrationBuilder.DropColumn(
                name: "VerreOD",
                table: "Visites");

            migrationBuilder.RenameColumn(
                name: "VerreOS",
                table: "Visites",
                newName: "verre");
        }
    }
}
