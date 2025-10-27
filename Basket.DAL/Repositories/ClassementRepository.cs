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
    public class ClassementRepository : BaseRepositoryAsync<int, Classement>, IClassementRepository
    {
        public ClassementRepository(Context context) : base(context) { }

        public async Task<IEnumerable<Classement>> GetAllByCategorieAsync(int categorieId)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(c => c.CategorieId == categorieId)
                .Include(c => c.Equipe)
                .Include(c => c.Saison)
                .ToListAsync();
        }

        public async Task<Classement?> GetByEquipeAsync(int equipeId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(c => c.Categorie)
                .Include(c => c.Saison)
                .FirstOrDefaultAsync(c => c.EquipeId == equipeId);
        }

        public async Task<Classement?> GetByEquipeAndCategorieAsync(int equipeId, int categorieId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(c => c.Equipe)
                .Include(c => c.Saison)
                .Include(c => c.Categorie)
                .FirstOrDefaultAsync(c => c.EquipeId == equipeId && c.CategorieId == categorieId);
        }
    }
}

