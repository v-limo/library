global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using FluentValidation;
global using LibraryApp.Infrastructure.Data;
global using LibraryApp.Application.Service.Interfaces;
global using LibraryApp.Application.Service.Implementations;
global using LibraryApp.Domain.Repositories;
global using LibraryApp.Infrastructure.Repositories;
global using LibraryApp.Domain.Entities;
global using LibraryApp.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// add db context
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// automatic validation
// https://docs.fluentvalidation.net/en/latest/aspnet.html#automatic-validation
// ...
// builder.Services.AddValidatorsFromAssemblyContaining<AuthorValidator>();
// builder.Services.AddValidatorsFromAssemblyContaining<BookValidator>();
// builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

// inject services - manual DI
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

// inject repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

// inject validation
builder.Services.AddScoped<IValidator<Author>, AuthorValidator>();
builder.Services.AddScoped<IValidator<Book>, BookValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();

// or register validations with DI package


// inject automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();