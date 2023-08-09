using PW.Domain.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.Application.Interfaces.Services.Membership
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync(int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false, bool disableTracking = true);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        void Update(User user);
        void Delete(User user);
        Task InsertAsync(User user);

    }
}
