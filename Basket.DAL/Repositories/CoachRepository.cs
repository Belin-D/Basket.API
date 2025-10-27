using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DAL.Repositories.Interfaces;
using Basket.DOMAINE.Models;

namespace Basket.DAL.Repositories
{
    public class CoachRepository : BaseRepositoryAsync<int, Coach>, ICoachRepository
    {
        public CoachRepository(Context context) : base(context) { }
    }
}
