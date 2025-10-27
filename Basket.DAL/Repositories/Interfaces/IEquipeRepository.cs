using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DOMAINE.Models;

namespace Basket.DAL.Repositories.Interfaces
{
    public interface IEquipeRepository : IRepository<int, Equipe>
    {
        Task<Equipe?> GetByCategorieAsync(int categorieId, string nom);
    }
}
