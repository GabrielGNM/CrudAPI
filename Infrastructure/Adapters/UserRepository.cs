using Application.Interfaces;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Adapters
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<IUser>> GetAllUsers()
        {
            var users = await _connection.QueryAsync<User>("SELECT * FROM Users");
            return users;
        }

        public async Task<IUser> GetUserById(Guid id)
        {
            var user = await _connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE Id = @Id", new { Id = id });
            return user;
        }

        public async Task AddUser(IUser user)
        {
            var sql = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
            await _connection.ExecuteAsync(sql, user);
        }

        public async Task UpdateUser(IUser user)
        {
            var sql = "UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, user);
        }

        public async Task DeleteUser(Guid id)
        {
            await _connection.ExecuteAsync("DELETE FROM Users WHERE Id = @Id", new { Id = id });
        }
    }
}

