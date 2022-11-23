using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskBusinessSolution.DAL.EF;
using TestTaskBusinessSolution.DAL.Entities;

namespace TestTaskBusinessSolution.DAL.Repositorys
{
    public class ProviderRepository : Repository<Provider>
    {
        public ProviderRepository(AppDbContext db) : base(db)
        {
        }
    }
}
