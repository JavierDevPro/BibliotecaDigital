using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDigital.Models;

public class Book
{
    
    public int Id { get; set; }
    
    public string Code { get; set; } = string.Empty;
    public int EjemplaresDisponibles { get; set; }
    
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}