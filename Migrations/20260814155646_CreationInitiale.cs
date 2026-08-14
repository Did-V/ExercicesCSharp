using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExercicesCSharp.Migrations
{
    /// <inheritdoc />
    public partial class CreationInitiale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DateInscription = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PANIERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PANIERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUITS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prix = table.Column<decimal>(type: "numeric", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    PanierId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUITS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUITS_PANIERS_PanierId",
                        column: x => x.PanierId,
                        principalTable: "PANIERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUITS_PanierId",
                table: "PRODUITS",
                column: "PanierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTS");

            migrationBuilder.DropTable(
                name: "PRODUITS");

            migrationBuilder.DropTable(
                name: "PANIERS");
        }
    }
}
