using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Domain.Entities;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
