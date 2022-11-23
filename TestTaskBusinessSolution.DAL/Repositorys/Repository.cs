using Microsoft.EntityFrameworkCore;
using TestTaskBusinessSolution.DAL.EF;
using TestTaskBusinessSolution.DAL.Interfaces;

namespace TestTaskBusinessSolution.DAL.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;
        public DbSet<T> Set { get; private set; }

        public Repository(AppDbContext db)
        {
            _db = db;
            var set = _db.Set<T>();
            set.Load();

            Set = set;
        }

        public IEnumerable<T> GetAll()
        {
            return Set;
        }

        public async Task<T?> Get(int id)
        {
            return await Set.FindAsync(id);
        }

        public async Task Create(T item)
        {
            Set.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            Set.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(T item)
        {
            Set.Remove(item);
            await _db.SaveChangesAsync();
        }
    }
}
