using AutoMapper;
using MediatR;
using ToDoApp.Application.Commons.Exceptions;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UseCases.ToDoLists.Commands.DeleteToDoList
{
    public record DeleteToDoListCommand(Guid ToDoListId) : IRequest<ToDoListDto>;

    public class DeleteToDoListCommandHandler : IRequestHandler<DeleteToDoListCommand, ToDoListDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteToDoListCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoListDto> Handle(DeleteToDoListCommand request, CancellationToken cancellationToken)
        {
            ToDoList maybeToDoList = await
                _context.ToDoLists.FindAsync(new object[] { request.ToDoListId });

            ValidateToDoListIsNotNull(request, maybeToDoList);

            _context.ToDoLists.Remove(maybeToDoList);

            await _context.SaveChangesAsync(cancellationToken);

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
