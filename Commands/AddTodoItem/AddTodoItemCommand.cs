using playground.Common.Interfaces;
using playground.Entities;
using playground.Events;

namespace playground.Commands.AddTodoItem;

public class AddTodoItemCommand : IRequest<Guid>
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTimeOffset? DueAt { get; set; }
}

public class AddTodoItemCommandHandler(IApplicationDbContext context) : IRequestHandler<AddTodoItemCommand, Guid>
{
    public async Task<Guid> Handle(AddTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            Title = request.Title,
            Description = request.Description,
            DueAt = request.DueAt
        };

        context.TodoItems.Add(entity);

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}