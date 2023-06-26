using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItems;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItemsToday
{
    public record GetToDoItemsTodayQuery : IRequest<ToDoItemDto[]>;

    public class GetToDoItemsTodayQueryHandler : IRequestHandler<GetToDoItemsTodayQuery, ToDoItemDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetToDoItemsTodayQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto[]> Handle(GetToDoItemsTodayQuery request, CancellationToken cancellationToken)
        {
            DateTime today = DateTime.Today;
            ToDoItem[] ToDoItems = await _context.ToDoItems
                .Where(item => item.DueDate.Date == today)
                .ToArrayAsync();

            return _mapper.Map<ToDoItemDto[]>(ToDoItems);
        }
    }
}
