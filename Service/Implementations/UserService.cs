using library.DTOs;
using library.Models;
using library.Repositories.Interfaces;
using library.Service.Interfaces;

namespace library.Service.Implementations;

public class UserService : IUserService
{
    // Will implement unit of work pattern and auto mapper in the future
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> CreateUserAsync(User user)
    {
        var createdUser = await _userRepository.CreateUserAsync(user);

        var userDTO = new UserDTO
        {
            Id = createdUser.Id,
            Email = createdUser.Email,
            Name = createdUser.Name,
        };

        return userDTO;
    }

    public async Task DeleteUserAsync(User user)
    {
        await _userRepository.DeleteUserAsync(user);
    }

    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();

        var userDTOs = new List<UserDTO>();

        foreach (var user in users)
        {
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
            };

            userDTOs.Add(userDTO);
        }

        return userDTOs;
    }

    public async Task<UserDTO> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);

        var userDTO = new UserDTO
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
        };

        return userDTO;
    }

    public async Task<UserDTO> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        var userDTO = new UserDTO
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
        };

        return userDTO;
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);
    }
}
