using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DOMAINE.Models;

namespace Basket.DAL.Repositories.Interfaces
{
    public interface IReservationRepository : IRepository<int, Reservation>
    {
        // 🔹 Récupère toutes les réservations d’un utilisateur
        Task<IEnumerable<Reservation>> GetByUtilisateurAsync(int utilisateurId);

        // 🔹 Récupère toutes les réservations d’un événement
        Task<IEnumerable<Reservation>> GetByEvenementAsync(int evenementId);

        // 🔹 Vérifie si un utilisateur a déjà réservé pour un événement
        Task<Reservation?> GetByUtilisateurAndEvenementAsync(int utilisateurId, int evenementId);

        // 🔹 Récupère toutes les réservations avec un statut donné
        Task<IEnumerable<Reservation>> GetByStatutAsync(bool statut);

        // 🔹 (Optionnel) Compte le nombre total de places réservées pour un événement
        Task<int> CountPlacesReservesAsync(int evenementId);
    }
}
