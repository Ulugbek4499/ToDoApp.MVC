using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ToDoApp.Application.UseCases.ToDoLists.Commands.CreateToDoList
{
    public class CreateToDoListCommandValidator : AbstractValidator<CreateToDoListCommand>
    {
        public CreateToDoListCommandValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("ToDoList name is required");
        }
    }
}
