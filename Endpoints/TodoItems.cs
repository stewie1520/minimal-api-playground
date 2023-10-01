using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<Ok<Guid>> AddTodoItem(ISender sender, AddTodoItemCommand command)
    {
        var created = await sender.Send(command);
        return TypedResults.Ok(created);
    }
}