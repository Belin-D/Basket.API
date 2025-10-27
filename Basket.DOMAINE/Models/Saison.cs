using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DOMAINE.Models
{
    public class Saison
    {
        public int Id { get; set; }
        public string? Nom { get; set; }

        // Une saison peut contenir plusieurs équipes
        public ICollection<Equipe> Equipes { get; set; } = new List<Equipe>();

    }
}
