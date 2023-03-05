using System;
namespace library.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public ICollection<Book> Books { get; set; }
}
