namespace library.Models;

public class User
{
    public int Id { get; set; }
    public ICollection<Book> Books { get; set; } = new HashSet<Book>();
}
