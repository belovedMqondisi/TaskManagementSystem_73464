
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem_73464.Data;
using TaskManagementSystem_73464.Models;

namespace TaskManagementSystem_73464.Controllers;

public class TasksController : Controller
{
    private readonly ApplicationDbContext _context;

    public TasksController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string sortBy = "newest")
    {
        var tasks = _context.Tasks
            .Include(t => t.AppUser)
            .AsQueryable();

        tasks = sortBy switch
        {
            "oldest" => tasks.OrderBy(t => t.CreatedAt),
            "priority" => tasks.OrderByDescending(t => t.Priority)
                               .ThenByDescending(t => t.CreatedAt),
            "title" => tasks.OrderBy(t => t.Title),
            _ => tasks.OrderByDescending(t => t.CreatedAt)
        };

        ViewBag.SortBy = sortBy;
        return View(await tasks.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        await LoadUsers();
        return View(new TaskItem());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Title,Description,Priority,AppUserId")] TaskItem task)
    {
        await ValidateUser(task.AppUserId);

        if (!ModelState.IsValid)
        {
            await LoadUsers(task.AppUserId);
            return View(task);
        }

        task.CreatedAt = DateTime.UtcNow;
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return NotFound();

        await LoadUsers(task.AppUserId);
        return View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,Title,Description,Priority,AppUserId")] TaskItem input)
    {
        if (id != input.Id) return BadRequest();

        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return NotFound();

        await ValidateUser(input.AppUserId);

        if (!ModelState.IsValid)
        {
            await LoadUsers(input.AppUserId);
            return View(input);
        }

        task.Title = input.Title;
        task.Description = input.Description;
        task.Priority = input.Priority;
        task.AppUserId = input.AppUserId;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var task = await _context.Tasks
            .Include(t => t.AppUser)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (task == null) return NotFound();
        return View(task);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadUsers(int? selectedId = null)
    {
        var users = await _context.Users
            .OrderBy(u => u.Name)
            .ToListAsync();

        ViewBag.Users = new SelectList(
            users, "Id", "Name", selectedId);
    }

    private async Task ValidateUser(int userId)
    {
        if (!await _context.Users.AnyAsync(u => u.Id == userId))
        {
            ModelState.AddModelError(
                nameof(TaskItem.AppUserId),
                "Please select a valid user.");
        }
    }
}
