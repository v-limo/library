using library.Models;
using library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories.Implementations;


public class BookRepository : IBookRepository
{


    private readonly ApplicationDbContext _DBcontext;

    public BookRepository(ApplicationDbContext DBcontext)
    {
        _DBcontext = DBcontext;
    }
    public async Task<Book> CreateBookAsync(Book book)
    {
        _DBcontext.Books.Add(book);
        await _DBcontext.SaveChangesAsync();
        // Return the book with the ID, Book from the DB
        return book;
    }

    public async Task DeleteBookAsync(Book book)
    {
        _DBcontext.Books.Remove(book);
        await _DBcontext.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _DBcontext.Books.ToListAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await _DBcontext.Books.
        FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Book>> GetBooksByAuthorIdAsync(int authorId)
    {
        return await _DBcontext.Books
        .Where(b => b.AuthorId == authorId)
        .ToListAsync();
    }

    public async Task<List<Book>> GetBooksByUserIdAsync(int userId)
    {
        return await _DBcontext.Books.
        Where(b => b.UserId == userId)
        .ToListAsync();
    }


    public async Task UpdateBookAsync(Book book)
    {
        _DBcontext.Books.Update(book);
        await _DBcontext.SaveChangesAsync();
    }
}
