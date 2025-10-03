using System.ComponentModel.DataAnnotations;

namespace BibliotecaDigital.Models;

public class User : Person
{
    public int Id { get; set; }
    public string Document { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string TelephoneNumber { get; set; } = string.Empty;
}