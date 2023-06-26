using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItemsWeek
{
    public record GetToDoItemsWeekQuery : IRequest<ToDoItemDto[]>;

    public class GetToDoItemsWeekQueryHandler : IRequestHandler<GetToDoItemsWeekQuery, ToDoItemDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetToDoItemsWeekQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto[]> Handle(GetToDoItemsWeekQuery request, CancellationToken cancellationToken)
        {
            DateTime today = DateTime.Today;
            DateTime nextWeek = today.AddDays(7);

            ToDoItem[] ToDoItems = await _context.ToDoItems
                .Where(item => item.DueDate.Date >= today && item.DueDate.Date <= nextWeek)
                .ToArrayAsync();

            return _mapper.Map<ToDoItemDto[]>(ToDoItems);
        }
    }
}
