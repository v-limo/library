using System.ComponentModel.DataAnnotations;

namespace library.Models;


public class Book
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
