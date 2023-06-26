using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.States;

namespace ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItemsNotStarted
{
    public record GetToDoItemsNotStartedQuery : IRequest<ToDoItemDto[]>;

    public class GetToDoItemsNotStartedQueryHandler : IRequestHandler<GetToDoItemsNotStartedQuery, ToDoItemDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetToDoItemsNotStartedQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto[]> Handle(GetToDoItemsNotStartedQuery request, CancellationToken cancellationToken)
        {
            ToDoItem[] ToDoItems = await _context.ToDoItems
             .Where(item => item.ToDoItemStatus == ToDoItemStatus.NotStarted)
             .ToArrayAsync();

            return _mapper.Map<ToDoItemDto[]>(ToDoItems);
        }
    }
}
