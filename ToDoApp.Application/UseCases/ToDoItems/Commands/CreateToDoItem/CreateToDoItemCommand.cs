using AutoMapper;
using MediatR;
using ToDoApp.Application.Commons.Exceptions;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.States;

namespace ToDoApp.Application.UseCases.ToDoItems.Commands.CreateToDoItem
{
    public class CreateToDoItemCommand: IRequest<ToDoItemDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public ToDoItemStatus ToDoItemStatus { get; set; }
        public Guid ToDoListId { get; set; }
    }

    public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, ToDoItemDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateToDoItemCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            ToDoList maybeTodoList = await
               _context.ToDoLists.FindAsync(new object[] { request.ToDoListId });

            ValidateToDoListIsNotNull(request, maybeTodoList);

            var toDoItem=new ToDoItem()
            {
                Title=request.Title,
                Description=request.Description,
                DueDate=request.DueDate,
                ToDoItemStatus=request.ToDoItemStatus,
                ToDoList=maybeTodoList
            };


            toDoItem = _context.ToDoItems.Add(toDoItem).Entity;
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ToDoItemDto>(toDoItem);
        }

        private void ValidateToDoListIsNotNull(CreateToDoItemCommand request, ToDoList? maybeTodoList)
        {
            if (maybeTodoList is null)
            {
                throw new NotFoundException(nameof(ToDoList), request.ToDoListId);
            }
        }
    }
}
