using playground.Common.Interfaces;
using playground.Entities;

namespace playground.Commands.AddTodoItem;

public class AddTodoItemCommand : IRequest<Guid>
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTimeOffset? DueAt { get; set; }
}

public class AddTodoItemCommandHandler : IRequestHandler<AddTodoItemCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public AddTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(AddTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            Title = request.Title,
            Description = request.Description,
            DueAt = request.DueAt
        };

        _context.TodoItems.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}