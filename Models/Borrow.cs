namespace BibliotecaDigital.Models;

public class Borrow
{
    public int Id { get; set; }
    public DateOnly ReturnDate { get; set; }
    
    public int UserId { get; set; }
    public User user { get; set; }
    
    public int BookId { get; set; }
    public Book book { get; set; }
}