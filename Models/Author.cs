using System.ComponentModel.DataAnnotations;

namespace BibliotecaDigital.Models;

public class Author
{
    [Key]
    public int IdAuthor { get; set; }
    public string Name { get; set; } = string.Empty;
}