using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExercicesCSharp.Migrations
{
    /// <inheritdoc />
    public partial class MAJClientCmd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CLIENTS",
                newName: "Nom");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "PANIERS",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PANIERS_ClientId",
                table: "PANIERS",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PANIERS_CLIENTS_ClientId",
                table: "PANIERS",
                column: "ClientId",
                principalTable: "CLIENTS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PANIERS_CLIENTS_ClientId",
                table: "PANIERS");

            migrationBuilder.DropIndex(
                name: "IX_PANIERS_ClientId",
                table: "PANIERS");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "PANIERS");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "CLIENTS",
                newName: "Name");
        }
    }
}
