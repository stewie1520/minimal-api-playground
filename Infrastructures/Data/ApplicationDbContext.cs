using System.Reflection;
using Microsoft.EntityFrameworkCore;
using playground.Common.Interfaces;
using playground.Entities;

namespace playground.Infrastructures.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public Task<bool> CanConnectAsync()
    {
        return Database.CanConnectAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}