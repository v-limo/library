namespace library.Models;


public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
}
