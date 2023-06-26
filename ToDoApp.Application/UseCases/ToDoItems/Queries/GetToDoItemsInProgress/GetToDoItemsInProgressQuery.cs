using AutoMapper;
using MediatR;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.States;

namespace ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItemsInProgress
{
    public record GetToDoItemsInProgressQuery : IRequest<ToDoItemDto[]>;

    public class GetToDoItemsInProgressQueryHandler : IRequestHandler<GetToDoItemsInProgressQuery, ToDoItemDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetToDoItemsInProgressQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto[]> Handle(GetToDoItemsInProgressQuery request, CancellationToken cancellationToken)
        {
            ToDoItem[] ToDoItems = await _context.ToDoItems
            .Where(item => item.ToDoItemStatus == ToDoItemStatus.InProgress)
            .ToArrayAsync();

            return _mapper.Map<ToDoItemDto[]>(ToDoItems);
        }
    }
}
