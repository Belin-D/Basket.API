using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Basket.DAL.Repositories.Interfaces;
using Basket.DOMAINE.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.DAL.Repositories
{
    public class AdresseTerrainRepository : BaseRepositoryAsync<int, Adresse_Terrain> , IAdresseTerrainRepository
    {
        public AdresseTerrainRepository(Context context) : base(context) { }

        public async Task<Adresse_Terrain?> GetByNameAsync(string nom)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Nom != null && a.Nom.ToLower() == nom.ToLower());
        }

        
    }
}
