using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using playground.Common.Exceptions;
using playground.Common.Interfaces;
using playground.Dtos;
using playground.Entities;

namespace playground.Queries.GetTodoItem;

public class GetTodoItemQuery : IRequest<TodoItemDto>
{
    public Guid Id { get; set; }
}

public class GetTodoItemQueryHandler
    (IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTodoItemQuery, TodoItemDto>
{
    public async Task<TodoItemDto> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
    {
        // find the todo item by id
        var todoItem = await context.TodoItems
            .AsNoTracking()
            .ProjectTo<TodoItemDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (todoItem is null)
            throw new NotFoundException<TodoItem>(request.Id);

        return todoItem;
    }
}