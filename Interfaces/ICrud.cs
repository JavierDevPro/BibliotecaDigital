using Microsoft.AspNetCore.Mvc;

namespace BibliotecaDigital.Interfaces;

public interface ICrud<T> where T: class
{
    Task<IActionResult> Register(T entity);
    Task<IActionResult> Delete(int id);
    Task<IActionResult> Update(int id, T entity);
    Task<IActionResult> ListAll();
}