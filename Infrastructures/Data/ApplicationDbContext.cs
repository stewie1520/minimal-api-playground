using System.Reflection;
using Microsoft.EntityFrameworkCore;
using playground.Common.Interfaces;
using playground.Entities;

namespace playground.Infrastructures.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options),
    IApplicationDbContext
{
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public Task<bool> CanConnectAsync(CancellationToken token)
    {
        return Database.CanConnectAsync(token);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}