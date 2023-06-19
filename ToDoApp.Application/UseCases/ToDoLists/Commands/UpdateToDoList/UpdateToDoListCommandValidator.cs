using FluentValidation;

namespace ToDoApp.Application.UseCases.ToDoLists.Commands.UpdateToDoList
{
    public class UpdateToDoListCommandValidator : AbstractValidator<UpdateToDoListCommand>
    {
        public UpdateToDoListCommandValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("ToDoList name is required.");
        }
    }
}
