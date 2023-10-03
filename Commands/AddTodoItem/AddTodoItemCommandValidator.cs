namespace playground.Commands.AddTodoItem;

public class AddTodoItemCommandValidator : AbstractValidator<AddTodoItemCommand>
{
    public AddTodoItemCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
    }
}