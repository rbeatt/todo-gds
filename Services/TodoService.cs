using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoGDS.Data;
using TodoGDS.Models;

namespace TodoGDS.Services;

public class TodoService
{
    private readonly TodoDbContext _context;

    public TodoService(TodoDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(int id)
    {
        return await _context.TodoItems.FindAsync(id);
    }

    public async Task<TodoItem> CreateAsync(TodoItem todoItem)
    {
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();
        return todoItem;
    }

    public async Task<TodoItem?> UpdateAsync(int id, TodoItem todoItem)
    {
        var existingItem = await _context.TodoItems.FindAsync(id);
        if (existingItem == null)
        {
            return null;
        }

        existingItem.Description = todoItem.Description;
        existingItem.IsCompleted = todoItem.IsCompleted;

        await _context.SaveChangesAsync();
        return existingItem;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);
        if (todoItem == null)
        {
            return false;
        }

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();
        return true;
    }
}
