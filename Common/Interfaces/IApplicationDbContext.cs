using Microsoft.EntityFrameworkCore;
using playground.Entities;

namespace playground.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    Task<bool> CanConnectAsync(CancellationToken token);
}