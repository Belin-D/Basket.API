using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DAL.Repositories.Interfaces;
using Basket.DOMAINE.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.DAL.Repositories
{
    public class JoueurRepository : BaseRepositoryAsync<int, Joueur>, IJoueurRepository
    {
        public JoueurRepository(Context context) : base(context) { }

        // 🔹 Récupère un joueur par son nom (insensible à la casse)
        public async Task<Joueur?> GetByNomAsync(string nom)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(j => j.Equipe)
                    .ThenInclude(e => e.Categorie)
                .FirstOrDefaultAsync(j => j.Nom != null && j.Nom.ToLower() == nom.ToLower());
        }

        // 🔹 Récupère tous les joueurs appartenant à une catégorie donnée
        public async Task<IEnumerable<Joueur>> GetByCategorieAsync(int categorieId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(j => j.Equipe)
                    .ThenInclude(e => e.Categorie)
                .Where(j => j.Equipe.CategorieId == categorieId)
                .ToListAsync();
        }

        // 🔹 Récupère tous les joueurs d’une équipe donnée
        public async Task<IEnumerable<Joueur>> GetByEquipeAsync(int equipeId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(j => j.Equipe)
                .Where(j => j.EquipeId == equipeId)
                .ToListAsync();
        }
    }
}
