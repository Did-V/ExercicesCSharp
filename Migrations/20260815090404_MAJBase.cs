using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExercicesCSharp.Migrations
{
    /// <inheritdoc />
    public partial class MAJBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUITS_PANIERS_PanierId",
                table: "PRODUITS");

            migrationBuilder.DropTable(
                name: "PANIERS");

            migrationBuilder.DropIndex(
                name: "IX_PRODUITS_PanierId",
                table: "PRODUITS");

            migrationBuilder.DropColumn(
                name: "PanierId",
                table: "PRODUITS");

            migrationBuilder.CreateTable(
                name: "COMMANDE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    ProduitId = table.Column<int>(type: "integer", nullable: false),
                    Quantite = table.Column<int>(type: "integer", nullable: false),
                    DateCommande = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMANDE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COMMANDE_CLIENTS_ClientId",
                        column: x => x.ClientId,
                        principalTable: "CLIENTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMMANDE_PRODUITS_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "PRODUITS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMMANDE_ClientId",
                table: "COMMANDE",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_COMMANDE_ProduitId",
                table: "COMMANDE",
                column: "ProduitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMMANDE");

            migrationBuilder.AddColumn<int>(
                name: "PanierId",
                table: "PRODUITS",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PANIERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PANIERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PANIERS_CLIENTS_ClientId",
                        column: x => x.ClientId,
                        principalTable: "CLIENTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUITS_PanierId",
                table: "PRODUITS",
                column: "PanierId");

            migrationBuilder.CreateIndex(
                name: "IX_PANIERS_ClientId",
                table: "PANIERS",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUITS_PANIERS_PanierId",
                table: "PRODUITS",
                column: "PanierId",
                principalTable: "PANIERS",
                principalColumn: "Id");
        }
    }
}
