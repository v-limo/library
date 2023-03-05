namespace library.Repositories.Implementations;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _DBcontext;

    public AuthorRepository(ApplicationDbContext DBcontext)
    {
        _DBcontext = DBcontext;
    }

    public async Task<Author> CreateAuthorAsync(Author author)
    {
        _DBcontext.Authors.Add(author);
        await _DBcontext.SaveChangesAsync();
        return author;
    }

    public async Task DeleteAuthorAsync(Author author)
    {
        _DBcontext.Authors.Remove(author);
        await _DBcontext.SaveChangesAsync();
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        return await _DBcontext.Authors.ToListAsync();
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        // Could be null, will be handled by the controller
        return await _DBcontext.Authors.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<Author>> GetAuthorsByNameAsync(string name)
    {
        var authors = await _DBcontext.Authors.Where(a => a.Name.Contains(name)).ToListAsync();

        if (authors == null)
        {
            throw new Exception("No authors found");
        }
        return authors;
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        _DBcontext.Authors.Update(author);
        await _DBcontext.SaveChangesAsync();
    }
}
