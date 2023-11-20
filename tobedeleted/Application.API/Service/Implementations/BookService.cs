namespace Application.API.Service.Implementations
{
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
            Book createdBook = await _bookRepository.CreateAsync(book);
            BookDTO bookDTO = _mapper.Map<BookDTO>(createdBook);
            return bookDTO;
        }

        public async Task DeleteBookAsync(int id)
        {
            _ = await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            IEnumerable<Book> books = await _bookRepository.GetAllAsync();
            List<BookDTO> bookDTOs = _mapper.Map<List<BookDTO>>(books);
            return bookDTOs;
        }

        public async Task<BookDTO> GetAuthorByEmailAsync(string email)
        {
            Book book = await _bookRepository.GetAuthorByEmailAsync(email);
            BookDTO bookDTO = _mapper.Map<BookDTO>(book);
            return bookDTO;
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            Book book = await _bookRepository.GetByIdAsync(id);
            BookDTO bookDTO = _mapper.Map<BookDTO>(book);
            return bookDTO;
        }

        public async Task<List<BookDTO>> GetBooksByAuthorIdAsync(int authorId)
        {
            List<Book> books = await _bookRepository.GetBooksByAuthorIdAsync(authorId);
            List<BookDTO> bookDTOs = _mapper.Map<List<BookDTO>>(books);
            return bookDTOs;
        }

        public async Task<List<BookDTO>> GetBooksByUserIdAsync(int userId)
        {
            List<Book> books = await _bookRepository.GetBooksByUserIdAsync(userId);
            List<BookDTO> bookDTOs = _mapper.Map<List<BookDTO>>(books);
            return bookDTOs;
        }

        public async Task UpdateBookAsync(Book book)
        {
            _ = await _bookRepository.UpdateAsync(book);
        }
    }
}
