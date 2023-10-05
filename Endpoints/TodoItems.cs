using Microsoft.AspNetCore.Http.HttpResults;
using playground.Commands.AddTodoItem;
using playground.Dtos;
using playground.Infrastructures;
using playground.Queries.GetTodoItem;

namespace playground.Endpoints;

public class TodoItems : EndpointGroupBase
{
    public override void Map(WebApplication application)
    {
        application
            .MapGroup(this)
            .MapPost(AddTodoItem)
            .MapGet(GetOne, "{id}");
    }

    public async Task<Ok<Guid>> AddTodoItem(ISender sender, AddTodoItemCommand command)
    {
        var created = await sender.Send(command);
        return TypedResults.Ok(created);
    }

    public async Task<Ok<TodoItemDto>> GetOne(ISender sender, Guid id)
    {
        var todoItem = await sender.Send(new GetTodoItemQuery { Id = id });
        return TypedResults.Ok(todoItem);
    }
}