using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DAL.Repositories.Interfaces;
using Basket.DOMAINE.Models;

namespace Basket.DAL.Repositories
{
    public class CalendrierMatchRepository : BaseRepositoryAsync<int, Calendrier_Match> , ICalendrierMatchRepository
    {
        public CalendrierMatchRepository(Context context) : base(context) { }
    }
}
