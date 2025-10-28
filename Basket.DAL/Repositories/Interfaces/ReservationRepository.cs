using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DOMAINE.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.DAL.Repositories.Interfaces
{
    public class ReservationRepository : BaseRepositoryAsync<int, Reservation>, IReservationRepository
    {
        public ReservationRepository(Context context) : base(context) { }

        // 🔹 Toutes les réservations d’un utilisateur
        public async Task<IEnumerable<Reservation>> GetByUtilisateurAsync(int utilisateurId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(r => r.Evenement)
                .Where(r => r.UtilisateurId == utilisateurId)
                .OrderByDescending(r => r.DateReservation)
                .ToListAsync();
        }

        // 🔹 Toutes les réservations pour un événement
        public async Task<IEnumerable<Reservation>> GetByEvenementAsync(int evenementId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(r => r.Utilisateur)
                .Where(r => r.EvenementId == evenementId)
                .OrderByDescending(r => r.DateReservation)
                .ToListAsync();
        }

        // 🔹 Vérifie si un utilisateur a déjà réservé un événement
        public async Task<Reservation?> GetByUtilisateurAndEvenementAsync(int utilisateurId, int evenementId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(r => r.Utilisateur)
                .Include(r => r.Evenement)
                .FirstOrDefaultAsync(r =>
                    r.UtilisateurId == utilisateurId &&
                    r.EvenementId == evenementId);
        }

        // 🔹 Toutes les réservations selon le statut (true = confirmée / false = annulée)
        public async Task<IEnumerable<Reservation>> GetByStatutAsync(bool statut)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(r => r.Utilisateur)
                .Include(r => r.Evenement)
                .Where(r => r.Statut == statut)
                .OrderByDescending(r => r.DateReservation)
                .ToListAsync();
        }

        // 🔹 Nombre total de places réservées pour un événement
        public async Task<int> CountPlacesReservesAsync(int evenementId)
        {
            return await _dbSet
                .Where(r => r.EvenementId == evenementId && r.Statut == true)
                .SumAsync(r => r.NbrPlaces);
        }
    }
}
