using BibliotecaDigital.Data;
using BibliotecaDigital.Interfaces;
using BibliotecaDigital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDigital.Controllers;

public class BookController : Controller, ICrud<Book>
{
    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _context.Books
            .Include(b => b.Author)
            .Take(6)
            .ToListAsync();
        return View(books);
    }
    
    public async Task<IActionResult> ListAll()
    {
        List<Book> books = await _context.Books
            .Include(b => b.Author)
            .ToListAsync();
        return View("Index",books);
    }
    
    public async Task<IActionResult> Register(Book entity)
    {
        // Validación de código requerido
        if (string.IsNullOrWhiteSpace(entity.Code))
        {
            TempData["Error"] = "El codigo del libro es obligatorio";
            return RedirectToAction(nameof(ListAll));
        }
        var normalizedCode = entity.Code.Trim();
        entity.Code = normalizedCode;
        
        if (await Exist(normalizedCode))
        {
            //dato temporal con alerta
            TempData["Error"] = $"El codigo {normalizedCode} ya esta registrado";
            return RedirectToAction(nameof(ListAll));
        }
        // Normalizar nombre del autor si viene por formulario
        var authorName = entity.Author?.Name;
        if (string.IsNullOrWhiteSpace(authorName))
        {
            // "fallback" si el form envió name="Author" en lugar de Author.Name
            authorName = Request.Form["Author"].FirstOrDefault();
        }
        if (!string.IsNullOrWhiteSpace(authorName))
        {
            var name = authorName.Trim();
            // Buscar autor existente (insensible a mayúsculas/minúsculas)
            var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.Name.ToLower() == name.ToLower());
            if (author == null)
            {
                author = new Author { Name = name };
                _context.Authors.Add(author);
                // Guardar para obtener IdAuthor
                await _context.SaveChangesAsync();
            }
            entity.AuthorId = author.IdAuthor;
            // Evitar que EF intente insertar nuevamente el autor por navegación
            entity.Author = null;
        }
        // Si no se envía AuthorName, se asume que viene AuthorId ya seleccionado en el form
        await _context.Books.AddAsync(entity);
        await _context.SaveChangesAsync();
        TempData["Success"] = "Libro registrado correctamente";
        return RedirectToAction(nameof(ListAll));
    }

    public async Task<bool> Exist(string code)
    {
        if (string.IsNullOrWhiteSpace(code)) return false;
        var normalized = code.Trim().ToLower();
        return await _context.Books.AnyAsync(b => b.Code.ToLower() == normalized);
    }

    
    public Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Update(int id, Book entity)
    {
        throw new NotImplementedException();
    }
}