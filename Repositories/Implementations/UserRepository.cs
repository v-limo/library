namespace library.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dBcontext;

    public UserRepository(ApplicationDbContext dBcontext)
    {
        _dBcontext = dBcontext;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var users = await _dBcontext.Users.ToListAsync();
        return users;
    }
    public async Task<User> GetById(int id)
    {
        var user = await _dBcontext.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<User> Create(User entity)
    {
        var user = await _dBcontext.Users.AddAsync(entity);
        _ = await _dBcontext.SaveChangesAsync();
        return user.Entity;
    }

    public async Task<User> Update(User entity)
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

    public async Task<User> Delete(int id)
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
}
