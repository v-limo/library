namespace library.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(author => author.Id).GreaterThan(0);

        RuleFor(author => author.Email).NotEmpty().EmailAddress().Length(3, 50);

        RuleFor(author => author.Books).Must(books => books.Count > 0);
    }
}
