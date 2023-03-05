using library.Models;
using library.Repositories.Interfaces;

namespace library.Repositories.Implementations;

public class AuthorRepository : IAuthorRepository
{
    public Task<Author> CreateAuthorAsync(Author author)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAuthorAsync(Author author)
    {
        throw new NotImplementedException();
    }

    public Task<List<Author>> GetAllAuthorsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Author> GetAuthorByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Author>> GetAuthorsByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAuthorAsync(Author author)
    {
        throw new NotImplementedException();
    }
}
