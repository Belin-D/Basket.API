using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DOMAINE.Models;

namespace Basket.DAL.Repositories.Interfaces
{
    public interface IAdresseTerrainRepository : IRepository <int, Adresse_Terrain>
    {
            Task<Adresse_Terrain?> GetByNameAsync(string nom); 
    }
}
