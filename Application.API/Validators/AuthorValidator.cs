namespace library.Validators;

public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(author => author.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        RuleFor(author => author.Name)
            .NotEmpty()
            .WithMessage("Name is must not be empty")
            .MaximumLength(50)
            .WithMessage("Name cannot exceed 50 characters");

        RuleFor(author => author.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid email format");

        RuleFor(author => author.Books)
            .NotEmpty()
            .WithMessage("At least one book must be associated with the author");
    }
}
