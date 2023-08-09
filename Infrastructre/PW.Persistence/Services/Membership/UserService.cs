using PW.Application.Interfaces.Repositories;
using PW.Application.Interfaces.Repositories.UnitOfWork;
using PW.Application.Interfaces.Services.Membership;
using PW.Domain.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.Persistence.Services.Membership
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork;
        IRepository<User> _userRepository;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }
        public async void Delete(User user)
        {
            _userRepository.Delete(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync(int pageIndex = 0, int pageSize = int.MaxValue, bool showDeleted = false, bool disableTracking = true)
        {       
            IEnumerable<User> users = await _userRepository.GetAllAsync(disableTracking: disableTracking);

            if (!showDeleted)
                users = users.Where(u => !u.Deleted);

            return users.Skip(pageIndex * pageSize).Take(pageSize).ToList();                
        }

        public async Task<User> GetByEmailAsync(string email)
        {
           return await _userRepository.GetFirstOrDefaultAsync(predicate:user => user.Email == email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetFirstOrDefaultAsync(predicate:user=>user.Id == id);
        }

        public async Task InsertAsync(User user)
        {
            await _userRepository.InsertAsync(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async void Update(User user)
        {
            _userRepository.Update(user);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
