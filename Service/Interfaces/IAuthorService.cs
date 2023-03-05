using library.DTOs;
using library.Models;

namespace library.Service.Interfaces;

public interface IAuthorService
{
    Task<List<AuthorDTO>> GetAllAuthorsAsync();
    Task<AuthorDTO> GetAuthorByIdAsync(int id);
    Task<List<AuthorDTO>> GetAuthorsByNameAsync(string name);
    Task<AuthorDTO> CreateAuthorAsync(Author author);
    Task UpdateAuthorAsync(Author author);
    Task DeleteAuthorAsync(Author author);

}
