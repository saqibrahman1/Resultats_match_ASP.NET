using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scoreGr03.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joueur_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateHeure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScoreDomicile = table.Column<int>(type: "int", nullable: false),
                    ScoreExterieur = table.Column<int>(type: "int", nullable: false),
                    EquipeDomicileId = table.Column<int>(type: "int", nullable: true),
                    EquipeExterieurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Equipe_EquipeDomicileId",
                        column: x => x.EquipeDomicileId,
                        principalTable: "Equipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Equipe_EquipeExterieurId",
                        column: x => x.EquipeExterieurId,
                        principalTable: "Equipe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "But",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoueurId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_But", x => x.Id);
                    table.ForeignKey(
                        name: "FK_But_Joueur_JoueurId",
                        column: x => x.JoueurId,
                        principalTable: "Joueur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_But_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_But_JoueurId",
                table: "But",
                column: "JoueurId");

            migrationBuilder.CreateIndex(
                name: "IX_But_MatchId",
                table: "But",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Joueur_EquipeId",
                table: "Joueur",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_EquipeDomicileId",
                table: "Match",
                column: "EquipeDomicileId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_EquipeExterieurId",
                table: "Match",
                column: "EquipeExterieurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "But");

            migrationBuilder.DropTable(
                name: "Joueur");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Equipe");
        }
    }
}
