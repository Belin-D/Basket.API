using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DOMAINE.Models
{
    public class Classement
    {
        public int Id { get; set; }

        // Statistiques de l’équipe
        public int Victoires { get; set; }
        public int Defaites { get; set; }
        public int MatchsNuls { get; set; }
        public int PointsPour { get; set; }
        public int PointsContre { get; set; }
        public int Forfaits { get; set; }

        public DateTime DateMiseAJour { get; set; }

        // Relations
        public int EquipeId { get; set; }
        public Equipe Equipe { get; set; } = null!;

        public int SaisonId { get; set; }
        public Saison Saison { get; set; } = null!;

        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; } = null!;

    }
}
