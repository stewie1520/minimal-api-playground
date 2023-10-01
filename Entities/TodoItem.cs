namespace playground.Entities;

public class TodoItem : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? DueAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
}