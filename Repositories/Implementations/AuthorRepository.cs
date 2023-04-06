namespace library.Repositories.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _dBcontext;

        public AuthorRepository(ApplicationDbContext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            List<Author> authors = await _dBcontext.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            Author author = await _dBcontext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            return author;
        }

        public async Task<Author> CreateAsync(Author entity)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Author> author =
                await _dBcontext.Authors.AddAsync(entity);
            _ = await _dBcontext.SaveChangesAsync();
            return author.Entity;
        }

        public async Task<Author> UpdateAsync(Author entity)
        {
            Author author = await _dBcontext.Authors.FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (author == null)
            {
                return null;
            }

            author.Id = entity.Id;
            author.Name = entity.Name;
            author.Books = entity.Books;
            _ = await _dBcontext.SaveChangesAsync();
            return author;
        }

        public async Task<Author> DeleteAsync(int id)
        {
            Author author = await _dBcontext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null)
            {
                return null;
            }
            _ = _dBcontext.Authors.Remove(author);
            return author;
        }

        public async Task<List<Author>> GetAuthorsByNameAsync(string name)
        {
            List<Author> authors = await _dBcontext.Authors.Where(a => a.Name.Contains(name)).ToListAsync();
            return authors;
        }

        public Task<Author> GetAuthorByEmailAsync(string email)
        {
            var author = _dBcontext.Authors.FirstOrDefaultAsync(a => a.Email == email);
            return author;
        }
    }
}
