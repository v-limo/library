
using LibraryApp.Domain.Entities;
namespace LibraryApp.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User> GetUserByEmailAsync(string email);
}
