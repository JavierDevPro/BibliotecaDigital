using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDigital.Models;

public class Book
{
    [Key]
    public int IdBook { get; set; }
    
    public string Code { get; set; } = string.Empty;
    public int EjemplaresDisponibles { get; set; }
    
    public int AuthorId { get; set; }
    [ForeignKey("AuthorId")]
    public Author Author { get; set; }
}