namespace library.Repositories.Interfaces;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<List<Author>> GetAuthorsByNameAsync(string name);
}
