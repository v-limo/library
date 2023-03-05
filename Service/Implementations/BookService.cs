namespace library.Service.Implementations;

public class BookService : IBookService
{
    // Will implement unit of work pattern and auto mapper in the future
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<BookDTO> CreateBookAsync(Book book)
    {
        var createdBook = await _bookRepository.CreateBookAsync(book);
        var bookDTO = _mapper.Map<BookDTO>(createdBook);
        return bookDTO;
    }

    public async Task DeleteBookAsync(Book book)
    {
        await _bookRepository.DeleteBookAsync(book);
    }

    public async Task<List<BookDTO>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllBooksAsync();
        var bookDTOs = _mapper.Map<List<BookDTO>>(books);
        return bookDTOs;
    }

    public async Task<BookDTO> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        var bookDTO = _mapper.Map<BookDTO>(book);
        return bookDTO;
    }

    public async Task<List<BookDTO>> GetBooksByAuthorIdAsync(int authorId)
    {
        var books = await _bookRepository.GetBooksByAuthorIdAsync(authorId);
        var bookDTOs = _mapper.Map<List<BookDTO>>(books);
        return bookDTOs;
    }

    public async Task<List<BookDTO>> GetBooksByUserIdAsync(int userId)
    {
        var books = await _bookRepository.GetBooksByUserIdAsync(userId);
        var bookDTOs = _mapper.Map<List<BookDTO>>(books);
        return bookDTOs;
    }

    public async Task UpdateBookAsync(Book book)
    {
        await _bookRepository.UpdateBookAsync(book);
    }
}
