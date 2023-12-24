using FluentValidation;
using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Validators;


public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(book => book.Id).GreaterThan(0).WithMessage("Id should be greater than Zero");

        RuleFor(book => book.Title).NotEmpty().MaximumLength(100).MaximumLength(2);

        RuleFor(book => book.Description).NotEmpty().MaximumLength(400);

        RuleFor(book => book.AuthorId).NotNull().NotEmpty();

        RuleFor(book => book.Author).NotEmpty().NotNull();

        RuleFor(book => book.User).NotEmpty().NotNull();

        RuleFor(book => book.UserId).NotEmpty().NotNull();
    }
}
