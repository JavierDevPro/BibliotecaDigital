using BibliotecaDigital.Data;
using BibliotecaDigital.Interfaces;
using BibliotecaDigital.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaDigital.Controllers;

public class UserController : Controller, ICrud<User>
{
    private readonly AppDbContext _context;
    
    public IActionResult Index()
    {
        return View();
    }

    public Task<IActionResult> Register(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Update(int id, User entity)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> ListAll()
    {
        throw new NotImplementedException();
    }
}