using BibliotecaDigital.Data;
using BibliotecaDigital.Interfaces;
using BibliotecaDigital.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaDigital.Controllers;

public class BorrowController : Controller, ICrud<Borrow>
{
    private readonly AppDbContext _context;
    
    public Task<IActionResult> Register(Borrow entity)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Update(int id, Borrow entity)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> ListAll()
    {
        throw new NotImplementedException();
    }
}