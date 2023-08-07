using PW.Application.Interfaces.Repositories;
using PW.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.Application.Interfaces.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
    }
}
