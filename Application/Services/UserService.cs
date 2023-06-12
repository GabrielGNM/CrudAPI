using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<IUser>> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public Task<IUser> GetUserById(Guid id)
        {
            return _userRepository.GetUserById(id);
        }

        public Task AddUser(IUser user)
        {
            return _userRepository.AddUser(user);
        }

        public Task UpdateUser(IUser user)
        {
            return _userRepository.UpdateUser(user);
        }

        public Task DeleteUser(Guid id)
        {
            return _userRepository.DeleteUser(id);
        }
    }
}
