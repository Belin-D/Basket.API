using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DOMAINE.Enum;
using Basket.DOMAINE.Models;

namespace Basket.DAL.Repositories.Interfaces
{
    public interface IUtilisateurRepository : IRepository<int, Utilisateur>
    {
        // 🔹 Récupère un utilisateur par email (utile pour la connexion)
        Task<Utilisateur?> GetByEmailAsync(string email);

        // 🔹 Vérifie la combinaison email/mot de passe (authentification)
        Task<Utilisateur?> GetByEmailAndPasswordAsync(string email, string password);

        // 🔹 Récupère tous les utilisateurs d’un rôle donné
        Task<IEnumerable<Utilisateur>> GetByRoleAsync(Roles role);

        // 🔹 Recherche par nom ou prénom (utile pour back-office/admin)
        Task<IEnumerable<Utilisateur>> SearchByNameAsync(string keyword);
    }
}
