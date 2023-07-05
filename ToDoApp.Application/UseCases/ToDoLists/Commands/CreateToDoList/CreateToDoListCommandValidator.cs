using FluentValidation;

namespace ToDoApp.Application.UseCases.ToDoLists.Commands.CreateToDoList
{
    public class CreateToDoListCommandValidator : AbstractValidator<CreateToDoListCommand>
    {
        public CreateToDoListCommandValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(50)
                .WithMessage("ToDoList name is required");
        }
    }
}
