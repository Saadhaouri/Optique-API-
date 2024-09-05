using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optique_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cop2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "verre",
                table: "Visites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "verre",
                table: "Visites");
        }
    }
}
