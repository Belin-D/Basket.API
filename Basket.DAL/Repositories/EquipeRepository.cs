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
    public class EquipeRepository : BaseRepositoryAsync<int, Equipe>, IEquipeRepository
    {
        public EquipeRepository(Context context) : base(context) { }

        public async Task<Equipe?> GetByCategorieAsync(int categorieId, string nom)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(e => e.Categorie)
                .Include(e => e.Coach)
                .Include(e => e.Saison)
                .FirstOrDefaultAsync(e =>
                    e.CategorieId == categorieId &&
                    e.Nom != null &&
                    e.Nom.ToLower() == nom.ToLower());
        }
    }
}
