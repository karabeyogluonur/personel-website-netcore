using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using PW.Domain.Common;
using System.Linq.Expressions;

namespace PW.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
             bool disableTracking = true);

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
                                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                  Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                                  bool disableTracking = true);

        ValueTask<EntityEntry<T>> InsertAsync(T entity, CancellationToken cancellationToken = default);
        void Delete(T entity);
        void Delete(int id);
        void Update(T entity);

    }
}
