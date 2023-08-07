using Microsoft.EntityFrameworkCore;
using PW.Application.Interfaces.Repositories;
using PW.Application.Interfaces.Repositories.UnitOfWork;
using PW.Domain.Common;
using PW.Persistence.Contexts;

namespace PW.Persistence.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PWDbContext _dbContext;
        private bool disposed = false;

        public UnitOfWork(PWDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("Database context can not be null.");

            _dbContext = dbContext;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _dbContext.Dispose();
            }

            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
