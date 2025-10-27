using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DOMAINE.Enum;

namespace Basket.DOMAINE.Models
{
    public class Calendrier_Match
    {
        public int Id { get; set; }
        public DateTime DateMatch { get; set; }
        public DateTime HeureMatch { get; set; }

        // Relations vers les équipes
        public int EquipeLocalId { get; set; }
        public Equipe EquipeLocal { get; set; } = null!;

        public int EquipeVisiteurId { get; set; }
        public Equipe EquipeVisiteur { get; set; } = null!;
        public int ScoreDomicile {  get; set; }
        public int ScoreVisiteur {  get; set; }
        public bool ForfaitDomicile { get; set; }
        public bool ForfaitVisiteur { get; set; }

        // Saison du match
        public int SaisonId { get; set; }
        public Saison Saison { get; set; } = null!;
        public TypeMatch typeMatch { get; set; } = TypeMatch.Championnat;

        public int? Adresse_TerrainId { get; set; }
        public Adresse_Terrain? Adresse_Terrain { get; set; }
    }
}
