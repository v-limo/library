namespace library.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
}
