using Microsoft.EntityFrameworkCore.Infrastructure;
using TestTaskBusinessSolution.DAL.EF;
using TestTaskBusinessSolution.DAL.Interfaces;

namespace TestTaskBusinessSolution.DAL.Repositorys
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appContext;

        private Dictionary<Type, object>? _repositories;

        public UnitOfWork(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Dictionary<Type, object>();

            if (hasCustomRepository)
            {
                var customRepo = _appContext.GetService<IRepository<TEntity>>();
                if (customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity);

            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_appContext);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public async void SaveChanges()
        {
            await _appContext.SaveChangesAsync();
        }

        public void Dispose() { }
    }
}
