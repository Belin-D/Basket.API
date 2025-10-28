using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DOMAINE.Models;

namespace Basket.DAL.Repositories.Interfaces
{
    public interface IJoueurRepository : IRepository<int, Joueur>
    {
        Task<Joueur?> GetByNomAsync(string nom);
        Task<IEnumerable<Joueur>> GetByCategorieAsync(int categorieId);
        Task<IEnumerable<Joueur>> GetByEquipeAsync(int equipeId);
    }
}
