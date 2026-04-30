using System.Linq.Expressions;

namespace GameZone.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task AddAsync(T entity);

        public Task AddRangeAsync(IEnumerable<T> entities);


        public Task<T?> GetByIdAsync(int id);

        public void Update(T entity);

        public void Delete(T entity);

        public void DeleteRange(IEnumerable<T> entities);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAsQuery(bool NoTracking = true);

        public Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(
                    Expression<Func<T, bool>>? predicate = null,
                    int? skip = null,
                    int? take = null,
                   params Expression<Func<T, object>>[] includes);

    }
}
