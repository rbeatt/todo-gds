using Microsoft.AspNetCore.Mvc;
using TodoGDS.Models;
using TodoGDS.Services;

namespace TodoGDS.Controllers;

public class TodoController : Controller
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }

    // GET: Todo
    public async Task<IActionResult> Index()
    {
        var todos = await _todoService.GetAllAsync();
        return View(todos);
    }

    // GET: Todo/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var todoItem = await _todoService.GetByIdAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }
        return View(todoItem);
    }

    // GET: Todo/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Todo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Description,IsCompleted")] TodoItem todoItem)
    {
        if (ModelState.IsValid)
        {
            await _todoService.CreateAsync(todoItem);
            return RedirectToAction(nameof(Index));
        }
        return View(todoItem);
    }

    // GET: Todo/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var todoItem = await _todoService.GetByIdAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }
        return View(todoItem);
    }

    // POST: Todo/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Description,IsCompleted")] TodoItem todoItem)
    {
        if (id != todoItem.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var updatedItem = await _todoService.UpdateAsync(id, todoItem);
            if (updatedItem == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        return View(todoItem);
    }

    // GET: Todo/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var todoItem = await _todoService.GetByIdAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }
        return View(todoItem);
    }

    // POST: Todo/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _todoService.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return RedirectToAction(nameof(Index));
    }
}
