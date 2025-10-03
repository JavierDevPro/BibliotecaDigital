using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDigital.Models;

public class Book
{
    
    public int Id { get; set; }
    public int IdAuthor { get; set; }
    public string Code { get; set; } = string.Empty;
    public int EjemplaresDisponibles { get; set; }

    [ForeignKey("IdAuthor")]
    public Author Author { get; set; }
}