using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDigital.Models;

public class Book
{
    [Key]
    public int IdBook { get; set; }
    
    public string Title { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int StockAvailable { get; set; }
    
    public int AuthorId { get; set; }
    [ForeignKey("AuthorId")]
    public Author Author { get; set; }
}