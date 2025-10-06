using BibliotecaDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDigital.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Borrow> Borrows { get; set; }
    
    //>>> dotnet ef migrations add InitialCreate
    //>>> dotnet ef database update
    public AppDbContext(DbContextOptions options) : base(options)
    {}
}