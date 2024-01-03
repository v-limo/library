
namespace LibraryApp.WebApi.Controllers.Extensions;

public static class ServicesExtension
{

    public static void AddCustomRouting(this IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);
    }

    public static void AddCustomDBcontext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );
    }



    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthorService, AuthorService>();


        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
    }


    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<Author>, AuthorValidator>();
        services.AddScoped<IValidator<Book>, BookValidator>();
        services.AddScoped<IValidator<User>, UserValidator>();
    }
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
