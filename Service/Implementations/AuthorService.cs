namespace library.Service.Implementations;

public class AuthorService : IAuthorService
{
    // Will implement unit of work pattern and auto mapper in the future
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public Task<AuthorDTO> CreateAuthorAsync(Author author)
    {
        return CreateAuthorAsync(author, _authorRepository);
    }

    public async Task<AuthorDTO> CreateAuthorAsync(
        Author author,
        IAuthorRepository _authorRepository
    )
    {
        var createdAuthor = await _authorRepository.CreateAsync(author);
        var authorDTO = _mapper.Map<AuthorDTO>(createdAuthor);
        return authorDTO;
    }

    public Task DeleteAuthorAsync(int id)
    {
        return _authorRepository.DeleteAsync(id);
    }


    public async Task<List<AuthorDTO>> GetAllAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        var authorDTOs = _mapper.Map<List<AuthorDTO>>(authors);
        return authorDTOs;
    }

    public async Task<AuthorDTO> GetAuthorByEmailAsync(string email)
    {
        var author = await _authorRepository.GetAuthorByEmailAsync(email);
        var authorDTO = _mapper.Map<AuthorDTO>(author);
        return authorDTO;
    }

    public async Task<AuthorDTO> GetAuthorByIdAsync(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        var authorDTO = _mapper.Map<AuthorDTO>(author);
        return authorDTO;
    }

    public async Task<List<AuthorDTO>> GetAuthorsByNameAsync(string name)
    {
        var authors = await _authorRepository.GetAuthorsByNameAsync(name);
        var authorDTOs = _mapper.Map<List<AuthorDTO>>(authors);
        return authorDTOs;
    }

    public async Task<AuthorDTO> UpdateAuthorAsync(Author author)
    {
        var updatedAuthor = await _authorRepository.UpdateAsync(author);
        var authorDTO = _mapper.Map<AuthorDTO>(updatedAuthor);
        return authorDTO;
    }
}
