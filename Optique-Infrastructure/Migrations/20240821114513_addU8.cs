using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optique_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addU8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OD_Add",
                table: "Visites");

            migrationBuilder.RenameColumn(
                name: "OS_Add",
                table: "Visites",
                newName: "Add");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Add",
                table: "Visites",
                newName: "OS_Add");

            migrationBuilder.AddColumn<decimal>(
                name: "OD_Add",
                table: "Visites",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
