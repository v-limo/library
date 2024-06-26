using AutoMapper;
using LibraryApp.Application.DTOs;
using LibraryApp.Application.Service.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Repositories;

namespace LibraryApp.Application.Service.Implementations;

public class UserService : IUserService
{
    // Will implement unit of work pattern and auto mapper in the future
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO> CreateUserAsync(User user)
    {
        var createdUser = await _userRepository.CreateAsync(user);
        var userDTO = _mapper.Map<UserDTO>(createdUser);
        return userDTO;
    }

    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        var userDTOs = _mapper.Map<List<UserDTO>>(users);
        return userDTOs;
    }

    public async Task<UserDTO> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        var userDTO = _mapper.Map<UserDTO>(user);
        return userDTO;
    }

    public async Task<UserDTO> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        var userDTO = _mapper.Map<UserDTO>(user);
        return userDTO;
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }
}
