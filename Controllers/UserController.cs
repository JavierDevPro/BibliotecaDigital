using BibliotecaDigital.Data;
using BibliotecaDigital.Interfaces;
using BibliotecaDigital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDigital.Controllers;

public class UserController : Controller, ICrud<User>
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        //no se implementa en el return el Task.FromResult
        var users = await _context.Users
            .Take(5)
            .ToListAsync();
        // View() es síncrono, pero el método sigue siendo asíncrono
        
        return View(users);
    }

    public async Task<IActionResult> ListAll()
    {
        List<User> users = await _context.Users.ToListAsync();
        //mostrar el resto de las consultas en el Index
        return View("Index",users);
    }
    [HttpPost]
    public async Task<IActionResult> Register(User entity)
    {
        if (await Exist(entity.Document))
        {
            //dato temporal con alerta
            TempData["Error"] = $"El documento {entity.Document} ya está registrado";
            return RedirectToAction(nameof(ListAll));
        }

        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
    
        TempData["Success"] = "Usuario registrado correctamente";
        return RedirectToAction(nameof(ListAll));
    }

    public async Task<bool> Exist(string document)
    {
        var usuarios  = await _context.Users.Where(u => u.Document == document).ToListAsync();
        if (usuarios.Any())
        {
            return true;
        }
        return false;
    }

    public Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Update(int id, User entity)
    {
        throw new NotImplementedException();
    }
}