using playground.Common.Mappings;
using playground.Entities;

namespace playground.Dtos;

public class TodoItemDto : IMapFrom<TodoItem>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? DueAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
}