using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DOMAINE.Models
{
    public class Adresse_Terrain
    {
        public int Id { get; set; }
        public string? Nom {  get; set; }
        public string? Rue { get; set; }
        public int? Numero { get; set; }
        public string? BoitePostal { get; set; }
        public int? Commune { get; set; }

        // Relation Many-to-Many
        public ICollection<Equipe> Equipes { get; set; } = new List<Equipe>();

    }
}
