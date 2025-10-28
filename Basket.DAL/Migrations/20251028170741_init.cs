using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdressesTerrains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    BoitePostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commune = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdressesTerrains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coachs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anniversaire = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coachs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saisons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saisons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaisonId = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipes_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipes_Coachs_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipes_Saisons_SaisonId",
                        column: x => x.SaisonId,
                        principalTable: "Saisons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evenements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<int>(type: "int", nullable: false),
                    NbrPlace = table.Column<int>(type: "int", nullable: false),
                    DateEvenement = table.Column<DateTime>(type: "date", nullable: false),
                    HeureEvenement = table.Column<TimeSpan>(type: "time", nullable: false),
                    SaisonId = table.Column<int>(type: "int", nullable: false),
                    AdresseTerrainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evenements_AdressesTerrains_AdresseTerrainId",
                        column: x => x.AdresseTerrainId,
                        principalTable: "AdressesTerrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evenements_Saisons_SaisonId",
                        column: x => x.SaisonId,
                        principalTable: "Saisons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendriersMatchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateMatch = table.Column<DateTime>(type: "date", nullable: false),
                    HeureMatch = table.Column<TimeSpan>(type: "time", nullable: false),
                    EquipeLocalId = table.Column<int>(type: "int", nullable: false),
                    EquipeVisiteurId = table.Column<int>(type: "int", nullable: false),
                    ScoreDomicile = table.Column<int>(type: "int", nullable: false),
                    ScoreVisiteur = table.Column<int>(type: "int", nullable: false),
                    ForfaitDomicile = table.Column<bool>(type: "bit", nullable: false),
                    ForfaitVisiteur = table.Column<bool>(type: "bit", nullable: false),
                    SaisonId = table.Column<int>(type: "int", nullable: false),
                    typeMatch = table.Column<int>(type: "int", nullable: false),
                    Adresse_TerrainId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendriersMatchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendriersMatchs_AdressesTerrains_Adresse_TerrainId",
                        column: x => x.Adresse_TerrainId,
                        principalTable: "AdressesTerrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CalendriersMatchs_Equipes_EquipeLocalId",
                        column: x => x.EquipeLocalId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CalendriersMatchs_Equipes_EquipeVisiteurId",
                        column: x => x.EquipeVisiteurId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CalendriersMatchs_Saisons_SaisonId",
                        column: x => x.SaisonId,
                        principalTable: "Saisons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Victoires = table.Column<int>(type: "int", nullable: false),
                    Defaites = table.Column<int>(type: "int", nullable: false),
                    MatchsNuls = table.Column<int>(type: "int", nullable: false),
                    PointsPour = table.Column<int>(type: "int", nullable: false),
                    PointsContre = table.Column<int>(type: "int", nullable: false),
                    Forfaits = table.Column<int>(type: "int", nullable: false),
                    DateMiseAJour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false),
                    SaisonId = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classements_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classements_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classements_Saisons_SaisonId",
                        column: x => x.SaisonId,
                        principalTable: "Saisons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipeTerrains",
                columns: table => new
                {
                    EquipesId = table.Column<int>(type: "int", nullable: false),
                    TerrainsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeTerrains", x => new { x.EquipesId, x.TerrainsId });
                    table.ForeignKey(
                        name: "FK_EquipeTerrains_AdressesTerrains_TerrainsId",
                        column: x => x.TerrainsId,
                        principalTable: "AdressesTerrains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeTerrains_Equipes_EquipesId",
                        column: x => x.EquipesId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Joueurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anniversaire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joueurs_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvenementId = table.Column<int>(type: "int", nullable: false),
                    NbrPlaces = table.Column<int>(type: "int", nullable: false),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Evenements_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendriersMatchs_Adresse_TerrainId",
                table: "CalendriersMatchs",
                column: "Adresse_TerrainId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendriersMatchs_EquipeLocalId",
                table: "CalendriersMatchs",
                column: "EquipeLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendriersMatchs_EquipeVisiteurId",
                table: "CalendriersMatchs",
                column: "EquipeVisiteurId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendriersMatchs_SaisonId",
                table: "CalendriersMatchs",
                column: "SaisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Classements_CategorieId",
                table: "Classements",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Classements_EquipeId",
                table: "Classements",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Classements_SaisonId",
                table: "Classements",
                column: "SaisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_CategorieId",
                table: "Equipes",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_CoachId",
                table: "Equipes",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_SaisonId",
                table: "Equipes",
                column: "SaisonId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeTerrains_TerrainsId",
                table: "EquipeTerrains",
                column: "TerrainsId");

            migrationBuilder.CreateIndex(
                name: "IX_Evenements_AdresseTerrainId",
                table: "Evenements",
                column: "AdresseTerrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Evenements_SaisonId",
                table: "Evenements",
                column: "SaisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Joueurs_EquipeId",
                table: "Joueurs",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EvenementId",
                table: "Reservations",
                column: "EvenementId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UtilisateurId",
                table: "Reservations",
                column: "UtilisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendriersMatchs");

            migrationBuilder.DropTable(
                name: "Classements");

            migrationBuilder.DropTable(
                name: "EquipeTerrains");

            migrationBuilder.DropTable(
                name: "Joueurs");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Evenements");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Coachs");

            migrationBuilder.DropTable(
                name: "AdressesTerrains");

            migrationBuilder.DropTable(
                name: "Saisons");
        }
    }
}
