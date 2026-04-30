using Microsoft.EntityFrameworkCore.Storage;

namespace GameZone.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<T> Repository<T>() where T : class;

        public Task<int> SaveChangesAsync();

        public Task<IDbContextTransaction> BeginTransactionAsync();


    }
}
