using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optique_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class isiteup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visite",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "Visite",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateVisite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OD_Sphere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OD_Cylinder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OD_Axis = table.Column<int>(type: "int", nullable: true),
                    OD_Add = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OS_Sphere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OS_Cylinder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OS_Axis = table.Column<int>(type: "int", nullable: true),
                    OS_Add = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visite_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visite_ClientId",
                table: "Visite",
                column: "ClientId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visite");

            migrationBuilder.AddColumn<string>(
                name: "Visite",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
