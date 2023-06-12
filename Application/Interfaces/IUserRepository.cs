using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<IUser>> GetAllUsers();
        Task<IUser> GetUserById(Guid id);
        Task AddUser(IUser user);
        Task UpdateUser(IUser user);
        Task DeleteUser(Guid id);
    }
}
