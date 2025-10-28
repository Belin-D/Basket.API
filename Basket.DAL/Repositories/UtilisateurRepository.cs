using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DAL.Repositories.Interfaces;
using Basket.DOMAINE.Enum;
using Basket.DOMAINE.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.DAL.Repositories
{
    public class UtilisateurRepository : BaseRepositoryAsync<int, Utilisateur>, IUtilisateurRepository
    {
        public UtilisateurRepository(Context context) : base(context) { }

        // 🔹 Récupère un utilisateur par email
        public async Task<Utilisateur?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(u => u.Reservations)
                .FirstOrDefaultAsync(u => u.Email != null && u.Email.ToLower() == email.ToLower());
        }

        // 🔹 Vérifie la combinaison email/mot de passe
        public async Task<Utilisateur?> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(u => u.Reservations)
                .FirstOrDefaultAsync(u =>
                    u.Email != null &&
                    u.Email.ToLower() == email.ToLower() &&
                    u.Password == password);
        }

        // 🔹 Récupère tous les utilisateurs d’un rôle donné
        public async Task<IEnumerable<Utilisateur>> GetByRoleAsync(Roles role)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(u => u.Roles == role)
                .OrderBy(u => u.Nom)
                .ToListAsync();
        }

        // 🔹 Recherche par nom ou prénom (recherche libre)
        public async Task<IEnumerable<Utilisateur>> SearchByNameAsync(string keyword)
        {
            keyword = keyword.ToLower();

            return await _dbSet
                .AsNoTracking()
                .Where(u =>
                    (u.Nom != null && u.Nom.ToLower().Contains(keyword)) ||
                    (u.Prenom != null && u.Prenom.ToLower().Contains(keyword)))
                .OrderBy(u => u.Nom)
                .ToListAsync();
        }
    }
}
