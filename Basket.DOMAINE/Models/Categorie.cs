using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DOMAINE.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string? Nom {  get; set; }

        // Une catégorie peut contenir plusieurs équipes
        public ICollection<Equipe> Equipes { get; set; } = new List<Equipe>();

    }
}
