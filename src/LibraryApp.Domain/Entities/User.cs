namespace LibraryApp.Domain.Entities;


public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = new HashSet<Book>();
}
