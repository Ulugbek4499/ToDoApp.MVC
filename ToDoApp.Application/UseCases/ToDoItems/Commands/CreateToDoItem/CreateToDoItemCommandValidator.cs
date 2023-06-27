using FluentValidation;

namespace ToDoApp.Application.UseCases.ToDoItems.Commands.CreateToDoItem
{
    public class CreateToDoItemCommandValidator : AbstractValidator<CreateToDoItemCommand>
    {
        public CreateToDoItemCommandValidator()
        {
            RuleFor(d => d.Title)
              .NotEmpty()
              .MaximumLength(50)
              .WithMessage("Title is required");

            RuleFor(d => d.Description)
              .NotEmpty()
              .MaximumLength(50)
              .WithMessage("Description is required");

            RuleFor(d => d.Note)
             .NotEmpty()
             .MaximumLength(50)
             .WithMessage("Note is required");

            RuleFor(d => d.DueDate)
               .NotEqual((DateTime)default)
               .WithMessage("Due Date is required.");

            RuleFor(d => d.ToDoListId)
                .NotEmpty()
                .NotEqual((Guid)default)
                .WithMessage("ToDoList Id is required.");
        }
    }
}
