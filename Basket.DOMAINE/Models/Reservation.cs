using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.DOMAINE.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        // Relation vers Evenement
        public int EvenementId { get; set; }
        public Evenement Evenement { get; set; } = null!;

        public int NbrPlaces { get; set; }
        public DateTime DateReservation { get; set; }
        public bool Statut { get; set; }

        // Relation vers Utilisateur
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = null!;

    }
}
