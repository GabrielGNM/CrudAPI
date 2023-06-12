using Domain.Interfaces;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<IUser>> GetAllUsers();
        Task<IUser> GetUserById(Guid id);
        Task AddUser(IUser user);
        Task UpdateUser(IUser user);
        Task DeleteUser(Guid id);
    }
}
