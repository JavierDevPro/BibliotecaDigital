namespace BibliotecaDigital.Models;

public class Borrows
{
    public int Id { get; set; }
    public DateOnly ReturnDate { get; set; }
    
    public int IdUser { get; set; }
    public int IdBook { get; set; }
    
    public User user { get; set; }
    public Book book { get; set; }
}