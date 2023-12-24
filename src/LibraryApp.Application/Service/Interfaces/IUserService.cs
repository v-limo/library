using LibraryApp.Application.DTOs;
using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Service.Interfaces;

public interface IUserService
{
    Task<List<UserDTO>> GetAllUsersAsync();
    Task<UserDTO> GetUserByIdAsync(int id);
    Task<UserDTO> GetUserByEmailAsync(string email);
    Task<UserDTO> CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
}
