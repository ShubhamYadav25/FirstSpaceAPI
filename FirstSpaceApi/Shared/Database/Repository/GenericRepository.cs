using FirstSpaceApi.Shared.Database.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstSpaceApi.Shared.Database.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class {

        protected DatabaseContext _databaseContext;

        public GenericRepository(DatabaseContext databaseContext)
            => _databaseContext = databaseContext;

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? _databaseContext.Set<T>().AsNoTracking() : _databaseContext.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? _databaseContext.Set<T>().Where(expression).AsNoTracking() : _databaseContext.Set<T>().Where(expression);
        public void Create(T entity) => _databaseContext.Set<T>().Add(entity);
        public void Update(T entity) => _databaseContext.Set<T>().Update(entity);
        public void Delete(T entity) => _databaseContext.Set<T>().Remove(entity);

    } 
}
