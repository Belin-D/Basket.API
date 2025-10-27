using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DOMAINE.Enum;

namespace Basket.DOMAINE.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Roles Roles { get; set; } = Roles.User;

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
