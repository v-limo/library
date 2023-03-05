using library.Models;
using library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _DBcontext;

    public UserRepository(ApplicationDbContext dBcontext)
    {
        _DBcontext = dBcontext;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        await _DBcontext.Users.AddAsync(user);
        await _DBcontext.SaveChangesAsync();
        return user;
    }

    public async Task DeleteUserAsync(User user)
    {
        _DBcontext.Users.Remove(user);
        await _DBcontext.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _DBcontext.Users.ToListAsync();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _DBcontext.Users.
        FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _DBcontext.Users.
        FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateUserAsync(User user)
    {
        _DBcontext.Users.Update(user);
        await _DBcontext.SaveChangesAsync();
    }
}
