using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDigital.Models;

public class Borrow
{
    [Key]
    public int IdBorrow { get; set; }
    public DateOnly ReturnDate { get; set; }
    
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User user { get; set; }
    
    public int BookId { get; set; }
    [ForeignKey("BookId")]
    public Book book { get; set; }
}