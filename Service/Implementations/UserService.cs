namespace library.Service.Implementations;

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
        var createdUser = await _userRepository.CreateUserAsync(user);
        var userDTO = _mapper.Map<UserDTO>(createdUser);
        return userDTO;
    }

    public async Task DeleteUserAsync(User user)
    {
        await _userRepository.DeleteUserAsync(user);
    }

    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
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
        var user = await _userRepository.GetUserByIdAsync(id);
        var userDTO = _mapper.Map<UserDTO>(user);
        return userDTO;
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);
    }
}
