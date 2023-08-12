namespace library.Service.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDTO> CreateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);
        Task<List<AuthorDTO>> GetAllAuthorsAsync();
        Task<AuthorDTO> GetAuthorByIdAsync(int id);
        Task<List<AuthorDTO>> GetAuthorsByNameAsync(string name);
        Task<AuthorDTO> UpdateAuthorAsync(Author author);
        Task<AuthorDTO> GetAuthorByEmailAsync(string email);
    }
}
