using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DOMAINE.Models;

namespace Basket.DAL.Repositories.Interfaces
{
    public interface IClassementRepository : IRepository<int, Classement>
    {
        Task<Classement?> GetByEquipeAsync(int equipeId);
        Task<IEnumerable<Classement>> GetAllByCategorieAsync(int categorieId);
        Task<Classement?> GetByEquipeAndCategorieAsync(int equipeId, int categorieId);
    }
}
