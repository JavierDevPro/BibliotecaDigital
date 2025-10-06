using BibliotecaDigital.Data;
using BibliotecaDigital.Interfaces;
using BibliotecaDigital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDigital.Controllers;

public class BorrowController : Controller, ICrud<Borrow>
{
    private readonly AppDbContext _context;

    public BorrowController(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        var borrows = await _context.Borrows
            .Include(b => b.user)
            .Include(b => b.book)
            .Take(6)
            .ToListAsync();
        ViewBag.Users = await _context.Users.ToListAsync();
        ViewBag.Books = await _context.Books.ToListAsync();
        return View(borrows);
    }

    public Task<IActionResult> Update(int id, Borrow entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> ListAll()
    {
        var borrows = await _context.Borrows
            .Include(b => b.user)
            .Include(b => b.book)
            .ToListAsync();
        ViewBag.Users = await _context.Users.ToListAsync();
        ViewBag.Books = await _context.Books.ToListAsync();
        return View("Index", borrows);
    }

    [HttpPost]
    public async Task<IActionResult> Register(Borrow entity)
    {
        // Validaciones básicas
        if (entity.UserId <= 0 || entity.BookId <= 0)
        {
            TempData["Error"] = "Debe seleccionar un usuario y un libro";
            return RedirectToAction(nameof(ListAll));
        }
        if (entity.ReturnDate == default)
        {
            TempData["Error"] = "Debe especificar una fecha de devolución";
            return RedirectToAction(nameof(ListAll));
        }

        var book = await _context.Books.FirstOrDefaultAsync(b => b.IdBook == entity.BookId);
        if (book == null)
        {
            TempData["Error"] = "El libro no existe";
            return RedirectToAction(nameof(ListAll));
        }
        if (book.StockAvailable <= 0)
        {
            TempData["Error"] = "No hay ejemplares disponibles para prestar";
            return RedirectToAction(nameof(ListAll));
        }

        // Descontar stock y registrar préstamo
        book.StockAvailable -= 1;
        await _context.Borrows.AddAsync(entity);
        await _context.SaveChangesAsync();
        TempData["Success"] = "Préstamo registrado exitosamente";
        return RedirectToAction(nameof(ListAll));
    }

    public Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Return(int id)
    {
        var borrow = await _context.Borrows.FirstOrDefaultAsync(b => b.IdBorrow == id);
        if (borrow == null)
        {
            TempData["Error"] = "Préstamo no encontrado";
            return RedirectToAction(nameof(ListAll));
        }
        var book = await _context.Books.FirstOrDefaultAsync(b => b.IdBook == borrow.BookId);
        if (book == null)
        {
            TempData["Error"] = "Libro no encontrado";
            return RedirectToAction(nameof(ListAll));
        }
        var today = DateOnly.FromDateTime(DateTime.Today);
        // Evitar devoluciones múltiples: solo si aún está activo (fecha de devolución hoy o futura)
        if (borrow.ReturnDate < today)
        {
            TempData["Error"] = "Este préstamo ya fue devuelto";
            return RedirectToAction(nameof(ListAll));
        }

        book.StockAvailable += 1;
        // Marcar como devuelto estableciendo la fecha de devolución al pasado
        borrow.ReturnDate = today.AddDays(-1);
        await _context.SaveChangesAsync();
        TempData["Success"] = "Libro devuelto exitosamente";
        return RedirectToAction(nameof(ListAll));
    }

    public async Task<IActionResult> HistoryByUser(int userId)
    {
        var query = from br in _context.Borrows
                    join u in _context.Users on br.UserId equals u.IdUser
                    join bk in _context.Books on br.BookId equals bk.IdBook
                    where br.UserId == userId
                    select new { br.IdBorrow, Usuario = u.Name, Libro = bk.Title, br.ReturnDate };

        var result = await query.ToListAsync();
        ViewBag.Result = result;
        return View("HistoryByUser");
    }

    public async Task<IActionResult> CurrentByBook(int bookId)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var query = from br in _context.Borrows
                    join u in _context.Users on br.UserId equals u.IdUser
                    join bk in _context.Books on br.BookId equals bk.IdBook
                    where br.BookId == bookId && br.ReturnDate >= today
                    select new { br.IdBorrow, Usuario = u.Name, Libro = bk.Title, br.ReturnDate };

        var result = await query.ToListAsync();
        ViewBag.Result = result;
        return View("CurrentByBook");
    }
}