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
    public class EvenementRepository : BaseRepositoryAsync<int, Evenement>, IEvenementRepository

    {
        public EvenementRepository(Context context) : base(context) { }
        

        public async Task<Evenement?> GetByNomAsync(string nom)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Nom != null && e.Nom.ToLower() == nom.ToLower());
        }
    }
}
