using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.States;

namespace ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItemsCompleted
{
    public record GetToDoItemsCompletedQuery : IRequest<ToDoItemDto[]>;

    public class GetToDoItemsCompletedQueryHandler : IRequestHandler<GetToDoItemsCompletedQuery, ToDoItemDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetToDoItemsCompletedQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto[]> Handle(GetToDoItemsCompletedQuery request, CancellationToken cancellationToken)
        {
            ToDoItem[] ToDoItems = await _context.ToDoItems
               .Where(item => item.ToDoItemStatus == ToDoItemStatus.Completed)
               .ToArrayAsync();

            return _mapper.Map<ToDoItemDto[]>(ToDoItems);
        }
    }
}
