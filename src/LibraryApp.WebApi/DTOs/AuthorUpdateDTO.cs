
namespace LibraryApp.WebApi.DTOs;

public class AuthorUpdateDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
