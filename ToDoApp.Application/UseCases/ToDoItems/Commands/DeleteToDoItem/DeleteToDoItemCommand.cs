using AutoMapper;
using MediatR;
using ToDoApp.Application.Commons.Exceptions;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UseCases.ToDoItems.Commands.DeleteToDoItem
{
    public record DeleteToDoItemCommand(Guid ToDoItemId) : IRequest<ToDoItemDto>;

    public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand, ToDoItemDto>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteToDoItemCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            ToDoItem? maybeToDoItem = await
                   _context.ToDoItems.FindAsync(new object[] { request.ToDoItemId });

            ValidateToDoItemIsNotNull(request, maybeToDoItem);

            _context.ToDoItems.Remove(maybeToDoItem);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ToDoItemDto>(maybeToDoItem);
        }

        private void ValidateToDoItemIsNotNull(DeleteToDoItemCommand request, ToDoItem? maybeToDoItem)
        {
            if (maybeToDoItem is null)
            {
                throw new NotFoundException(nameof(ToDoItem), request.ToDoItemId);
            }
        }
    }
}
