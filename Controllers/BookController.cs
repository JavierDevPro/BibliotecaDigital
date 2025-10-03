using BibliotecaDigital.Data;
using BibliotecaDigital.Interfaces;
using BibliotecaDigital.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaDigital.Controllers;

public class BookController : Controller, ICrud<Book>
{
    private readonly AppDbContext _context;
    
    public Task<IActionResult> Register(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Update(int id, Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> ListAll()
    {
        throw new NotImplementedException();
    }
}