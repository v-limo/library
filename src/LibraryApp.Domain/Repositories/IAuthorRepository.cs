
using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Repositories;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<List<Author>> GetAuthorsByNameAsync(string name);

    public Task<Author> GetAuthorByEmailAsync(string email);
}
