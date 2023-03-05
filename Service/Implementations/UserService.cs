using library.DTOs;
using library.Models;
using library.Service.Interfaces;

namespace library.Service.Implementations;


public class UserService : IUserService
{
    public Task<UserDTO> CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserDTO>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}
