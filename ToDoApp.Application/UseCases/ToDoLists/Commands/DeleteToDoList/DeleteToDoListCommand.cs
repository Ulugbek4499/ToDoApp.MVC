using AutoMapper;
using MediatR;
using ToDoApp.Application.Commons.Exceptions;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoLists.Notifications;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UseCases.ToDoLists.Commands.DeleteToDoList
{
    public record DeleteToDoListCommand(Guid ToDoListId) : IRequest<ToDoListDto>;

    public class DeleteToDoListCommandHandler : IRequestHandler<DeleteToDoListCommand, ToDoListDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeleteToDoListCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ToDoListDto> Handle(DeleteToDoListCommand request, CancellationToken cancellationToken)
        {
            ToDoList maybeToDoList = await
                _context.ToDoLists.FindAsync(new object[] { request.ToDoListId });

            ValidateToDoListIsNotNull(request, maybeToDoList);

            _context.ToDoLists.Remove(maybeToDoList);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ToDoListDeletedNotification(maybeToDoList.Name));

            return _mapper.Map<ToDoListDto>(maybeToDoList);
        }

        private static void ValidateToDoListIsNotNull(DeleteToDoListCommand request, ToDoList maybeToDoList)
        {
            if (maybeToDoList is null)
            {
                throw new NotFoundException(nameof(ToDoList), request.ToDoListId);
            }
        }
    }
}
