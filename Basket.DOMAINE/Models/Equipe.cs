using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DOMAINE.Models
{
    public class Equipe
    {
        public int Id { get; set; }
        public string? Nom {  get; set; }

        // Relation vers Saison
        public int SaisonId { get; set; }
        public Saison Saison { get; set; } = null!;

        // Relation vers Categorie
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; } = null!;

        // Relation vers Coach
        public int CoachId { get; set; }
        public Coach Coach { get; set; } = null!;

        // Relation : une équipe peut avoir plusieurs joueurs
        public ICollection<Joueur> Joueurs { get; set; } = new List<Joueur>();

        // Relation Many-to-Many
        public ICollection<Adresse_Terrain> Terrains { get; set; } = new List<Adresse_Terrain>();

    }
}
