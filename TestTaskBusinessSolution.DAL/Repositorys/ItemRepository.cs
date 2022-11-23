using TestTaskBusinessSolution.DAL.EF;
using TestTaskBusinessSolution.DAL.Entities;

namespace TestTaskBusinessSolution.DAL.Repositorys
{
    public class ItemRepository : Repository<Item>
    {
        public ItemRepository(AppDbContext db) : base(db)
        {
        }
    }
}
