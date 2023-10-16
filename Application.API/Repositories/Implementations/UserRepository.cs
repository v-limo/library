namespace Application.API.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dBcontext;

    public UserRepository(ApplicationDbContext dBcontext)
    {
        _dBcontext = dBcontext;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _dBcontext.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _dBcontext.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<User> CreateAsync(User entity)
    {
        var user = await _dBcontext.Users.AddAsync(entity);
        _ = await _dBcontext.SaveChangesAsync();
        return user.Entity;
    }

    public async Task<User>? UpdateAsync(User entity)
    {
        var user = await _dBcontext.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);
        if (user == null)
        {
            return null;
        }

        user.Id = entity.Id;
        user.Email = entity.Email;
        _ = await _dBcontext.SaveChangesAsync();
        return user;
    }

    public async Task<User>? DeleteAsync(int id)
    {
        var user = await _dBcontext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            return null;
        }
        _ = _dBcontext.Users.Remove(user);
        _ = await _dBcontext.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _dBcontext.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }
}
