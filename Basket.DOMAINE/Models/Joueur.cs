using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DOMAINE.Models
{
    public class Joueur
    {
        public int Id { get; set; }
        public string? Nom {  get; set; }
        public string? Prenom {  set; get; }
        public DateTime? Anniversaire { set; get; }

        // Relation vers Equipe
        public int EquipeId { get; set; }
        public Equipe Equipe { get; set; } = null!;

    }
}
