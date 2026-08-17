using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExercicesCSharp.Migrations
{
    /// <inheritdoc />
    public partial class MAJBase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMMANDE_CLIENTS_ClientId",
                table: "COMMANDE");

            migrationBuilder.DropForeignKey(
                name: "FK_COMMANDE_PRODUITS_ProduitId",
                table: "COMMANDE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUITS",
                table: "PRODUITS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_COMMANDE",
                table: "COMMANDE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CLIENTS",
                table: "CLIENTS");

            migrationBuilder.RenameTable(
                name: "PRODUITS",
                newName: "Produits");

            migrationBuilder.RenameTable(
                name: "COMMANDE",
                newName: "Commande");

            migrationBuilder.RenameTable(
                name: "CLIENTS",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_COMMANDE_ProduitId",
                table: "Commande",
                newName: "IX_Commande_ProduitId");

            migrationBuilder.RenameIndex(
                name: "IX_COMMANDE_ClientId",
                table: "Commande",
                newName: "IX_Commande_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produits",
                table: "Produits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commande",
                table: "Commande",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Clients_ClientId",
                table: "Commande",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Produits_ProduitId",
                table: "Commande",
                column: "ProduitId",
                principalTable: "Produits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Clients_ClientId",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Produits_ProduitId",
                table: "Commande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produits",
                table: "Produits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commande",
                table: "Commande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Produits",
                newName: "PRODUITS");

            migrationBuilder.RenameTable(
                name: "Commande",
                newName: "COMMANDE");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "CLIENTS");

            migrationBuilder.RenameIndex(
                name: "IX_Commande_ProduitId",
                table: "COMMANDE",
                newName: "IX_COMMANDE_ProduitId");

            migrationBuilder.RenameIndex(
                name: "IX_Commande_ClientId",
                table: "COMMANDE",
                newName: "IX_COMMANDE_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUITS",
                table: "PRODUITS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_COMMANDE",
                table: "COMMANDE",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CLIENTS",
                table: "CLIENTS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_COMMANDE_CLIENTS_ClientId",
                table: "COMMANDE",
                column: "ClientId",
                principalTable: "CLIENTS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COMMANDE_PRODUITS_ProduitId",
                table: "COMMANDE",
                column: "ProduitId",
                principalTable: "PRODUITS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
