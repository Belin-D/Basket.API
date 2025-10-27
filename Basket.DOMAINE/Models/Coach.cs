using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DOMAINE.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string? Nom {  get; set; }
        public string? Prenom { get; set; }
        public DateTime Anniversaire { get; set; }

        // Un coach peut avoir plusieurs équipes (dans différentes catégories et saisons)
        public ICollection<Equipe> Equipes { get; set; } = new List<Equipe>();
    }
}
