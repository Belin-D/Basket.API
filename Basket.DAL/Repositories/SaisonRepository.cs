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
    public class SaisonRepository : BaseRepositoryAsync<int, Saison>, ISaisonRepository
    {
        public SaisonRepository(Context context) : base(context)
        {
        }

        
    }
}
