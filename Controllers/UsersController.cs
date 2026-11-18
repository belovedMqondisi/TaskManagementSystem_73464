
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem_73464.Data;
using TaskManagementSystem_73464.Models;

namespace TaskManagementSystem_73464.Controllers;

public class UsersController : Controller
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _context.Users
            .OrderBy(u => u.Name)
            .ToListAsync();

        return View(users);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AppUser user)
    {
        ModelState.Remove(nameof(AppUser.Tasks));

        if (!ModelState.IsValid)
            return View(user);

        if (await _context.Users.AnyAsync(u => u.Email == user.Email))
        {
            ModelState.AddModelError(
                nameof(AppUser.Email),
                "This email address is already registered.");

            return View(user);
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
