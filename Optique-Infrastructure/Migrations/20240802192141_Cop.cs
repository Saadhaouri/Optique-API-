using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Optique_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visite_Clients_ClientId",
                table: "Visite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visite",
                table: "Visite");

            migrationBuilder.RenameTable(
                name: "Visite",
                newName: "Visites");

            migrationBuilder.RenameIndex(
                name: "IX_Visite_ClientId",
                table: "Visites",
                newName: "IX_Visites_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visites",
                table: "Visites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visites_Clients_ClientId",
                table: "Visites",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visites_Clients_ClientId",
                table: "Visites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visites",
                table: "Visites");

            migrationBuilder.RenameTable(
                name: "Visites",
                newName: "Visite");

            migrationBuilder.RenameIndex(
                name: "IX_Visites_ClientId",
                table: "Visite",
                newName: "IX_Visite_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visite",
                table: "Visite",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visite_Clients_ClientId",
                table: "Visite",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
