using library.DTOs;
using library.Models;
using library.Repositories.Interfaces;
using library.Service.Interfaces;

namespace library.Service.Implementations;

public class AuthorService : IAuthorService
{
    // Will implement unit of work pattern and auto mapper in the future


    private readonly IAuthorRepository _authorRepository;

    public Task<AuthorDTO> CreateAuthorAsync(Author author)
    {
        return CreateAuthorAsync(author, _authorRepository);
    }

    public async Task<AuthorDTO> CreateAuthorAsync(
        Author author,
        IAuthorRepository _authorRepository
    )
    {
        var createdAuthor = await _authorRepository.CreateAuthorAsync(author);

        var authorDTO = new AuthorDTO { Id = createdAuthor.Id, Name = createdAuthor.Name, };

        return authorDTO;
    }

    public async Task DeleteAuthorAsync(Author author)
    {
        await _authorRepository.DeleteAuthorAsync(author);
    }

    public async Task<List<AuthorDTO>> GetAllAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllAuthorsAsync();

        var authorDTOs = new List<AuthorDTO>();

        foreach (var author in authors)
        {
            var authorDTO = new AuthorDTO { Id = author.Id, Name = author.Name, };

            authorDTOs.Add(authorDTO);
        }

        return authorDTOs;
    }

    public async Task<AuthorDTO> GetAuthorByIdAsync(int id)
    {
        var author = await _authorRepository.GetAuthorByIdAsync(id);

        var authorDTO = new AuthorDTO { Id = author.Id, Name = author.Name, };

        return authorDTO;
    }

    public async Task<List<AuthorDTO>> GetAuthorsByNameAsync(string name)
    {
        var authors = await _authorRepository.GetAuthorsByNameAsync(name);

        var authorDTOs = new List<AuthorDTO>();

        foreach (var author in authors)
        {
            var authorDTO = new AuthorDTO { Id = author.Id, Name = author.Name, };

            authorDTOs.Add(authorDTO);
        }

        return authorDTOs;
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        await _authorRepository.UpdateAuthorAsync(author);
    }
}
