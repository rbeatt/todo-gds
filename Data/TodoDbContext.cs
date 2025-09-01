using Microsoft.EntityFrameworkCore;
using TodoGDS.Models;

namespace TodoGDS.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure TodoItem entity
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.IsCompleted)
                .IsRequired();
        });
    }
}
