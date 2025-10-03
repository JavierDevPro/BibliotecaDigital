using Microsoft.EntityFrameworkCore;

namespace BibliotecaDigital.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}
}