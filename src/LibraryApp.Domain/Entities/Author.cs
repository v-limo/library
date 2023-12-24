namespace LibraryApp.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Book> Books { get; set; }
}
