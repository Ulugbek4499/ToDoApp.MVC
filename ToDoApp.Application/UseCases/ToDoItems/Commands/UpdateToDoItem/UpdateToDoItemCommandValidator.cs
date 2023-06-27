using FluentValidation;

namespace ToDoApp.Application.UseCases.ToDoItems.Commands.UpdateToDoItem
{
    public class UpdateToDoItemCommandValidator : AbstractValidator<UpdateToDoItemCommand>
    {
        public UpdateToDoItemCommandValidator()
        {
            RuleFor(d => d.Id)
               .NotEmpty()
               .NotEqual((Guid)default)
               .WithMessage("ToDoItem Id is required.");

            RuleFor(d => d.Title).NotEmpty()
             .MaximumLength(50)
             .WithMessage("Title is required");

            RuleFor(d => d.Description).NotEmpty()
              .MaximumLength(300)
              .WithMessage("Description is required");

            RuleFor(d => d.Note).NotEmpty()
              .MaximumLength(300)
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
