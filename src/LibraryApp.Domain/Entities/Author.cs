namespace LibraryApp.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = [];
}
