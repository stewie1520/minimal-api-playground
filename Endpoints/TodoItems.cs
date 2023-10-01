using playground.Commands.AddTodoItem;
using playground.Infrastructures;

namespace playground.Endpoints;

public class TodoItems : EndpointGroupBase
{
    public override void Map(WebApplication application)
    {
        application
            .MapGroup(this)
            .MapPost(AddTodoItem);
    }

    public async Task<Guid> AddTodoItem(ISender sender, AddTodoItemCommand command)
    {
        return await sender.Send(command);
    }
}