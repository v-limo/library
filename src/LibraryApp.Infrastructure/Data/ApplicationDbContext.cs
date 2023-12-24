using LibraryApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; } = default!;

    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().ToTable("Authorss");
        modelBuilder.Entity<Book>().ToTable("Books");
        modelBuilder.Entity<User>().ToTable("Users");
    }
}
