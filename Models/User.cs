namespace library.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
