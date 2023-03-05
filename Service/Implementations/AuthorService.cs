using library.DTOs;
using library.Models;
using library.Service.Interfaces;

namespace library.Service.Implementations;


public class AuthorService : IAuthorService
{
    public Task<AuthorDTO> CreateAuthorAsync(Author author)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAuthorAsync(Author author)
    {
        throw new NotImplementedException();
    }

    public Task<List<AuthorDTO>> GetAllAuthorsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AuthorDTO> GetAuthorByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AuthorDTO>> GetAuthorsByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAuthorAsync(Author author)
    {
        throw new NotImplementedException();
    }
}
