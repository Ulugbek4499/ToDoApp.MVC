using AutoMapper;
using MediatR;
using ToDoApp.Application.Commons.Exceptions;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoItems.Notifications;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UseCases.ToDoItems.Commands.DeleteToDoItem
{
    public record DeleteToDoItemCommand(Guid ToDoItemId) : IRequest<ToDoItemDto>;

    public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand, ToDoItemDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeleteToDoItemCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ToDoItemDto> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            ToDoItem? maybeToDoItem = await
                   _context.ToDoItems.FindAsync(new object[] { request.ToDoItemId });

            ValidateToDoItemIsNotNull(request, maybeToDoItem);

            _context.ToDoItems.Remove(maybeToDoItem);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ToDoItemDeletedNotification(maybeToDoItem.Title));

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
