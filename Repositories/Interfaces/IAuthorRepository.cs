namespace library.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task<List<Author>> GetAllAuthorsAsync();
    Task<Author> GetAuthorByIdAsync(int id);
    Task<List<Author>> GetAuthorsByNameAsync(string name);
    Task<Author> CreateAuthorAsync(Author author);
    Task UpdateAuthorAsync(Author author);
    Task DeleteAuthorAsync(Author author);

}
