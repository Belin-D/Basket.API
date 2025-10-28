using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DOMAINE.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        public string? Nom {  get; set; }
        public string? Description { get; set; }
        public int Prix { get; set; }
        public int NbrPlace { get; set; }
        public DateTime DateEvenement { get; set; }
        public TimeSpan HeureEvenement { get; set; }

        // Relations
        public int SaisonId { get; set; }
        public Saison Saison { get; set; } = null!;

        public int AdresseTerrainId { get; set; }
        public Adresse_Terrain AdresseTerrain { get; set; } = null!;

    }
}
