namespace Application.API.Repositories.Interfaces;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<List<Author>> GetAuthorsByNameAsync(string name);

    public Task<Author> GetAuthorByEmailAsync(string email);
}
