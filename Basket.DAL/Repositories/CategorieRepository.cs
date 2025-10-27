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
    public class CategorieRepository : BaseRepositoryAsync<int, Categorie>, ICategorieRepository
    {
        public CategorieRepository(Context context) : base(context) { }
        public async Task<Categorie?> GetByNameAsync(string nom)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Nom != null && c.Nom.ToLower() == nom.ToLower());
        }
    }
}
