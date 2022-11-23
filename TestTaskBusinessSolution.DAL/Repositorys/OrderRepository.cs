using TestTaskBusinessSolution.DAL.EF;
using TestTaskBusinessSolution.DAL.Entities;

namespace TestTaskBusinessSolution.DAL.Repositorys
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(AppDbContext db) : base(db)
        {
        }
    }
}
