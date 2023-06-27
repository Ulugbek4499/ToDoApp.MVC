using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItems;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.States;

namespace ToDoApp.Application.UseCases.ToDoItems.Queries.GetInformationAboutToDoItems
{
    public record GetInformationAboutToDoItemsQuery: IRequest<int[]>;

    public class GetInformationAboutToDoItemsQueryHandler : IRequestHandler<GetInformationAboutToDoItemsQuery, int[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetInformationAboutToDoItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int[]> Handle(GetInformationAboutToDoItemsQuery request, CancellationToken cancellationToken)
        {
            ToDoItem[] AllToDoItems = await _context.ToDoItems.ToArrayAsync();

            DateTime today = DateTime.Today;
            ToDoItem[] TodayToDoItems = await _context.ToDoItems
                .Where(item => item.DueDate.Date == today)
                .ToArrayAsync();

            DateTime nextWeek = today.AddDays(7);

            ToDoItem[] WeekToDoItems = await _context.ToDoItems
                .Where(item => item.DueDate.Date >= today && item.DueDate.Date <= nextWeek)
                .ToArrayAsync();

            ToDoItem[] CompletedToDoItems = await _context.ToDoItems
              .Where(item => item.ToDoItemStatus == ToDoItemStatus.Completed)
              .ToArrayAsync();

            ToDoItem[] InProgressToDoItems = await _context.ToDoItems
                .Where(item => item.ToDoItemStatus == ToDoItemStatus.InProgress)
                .ToArrayAsync();

            ToDoItem[] NotStartedToDoItems = await _context.ToDoItems
                 .Where(item => item.ToDoItemStatus == ToDoItemStatus.NotStarted)
                .ToArrayAsync();

            int[] result = new int[]
            {
                TodayToDoItems.Count(),
                WeekToDoItems.Count(),
                AllToDoItems.Count(),
                CompletedToDoItems.Count(),
                InProgressToDoItems.Count(),
                NotStartedToDoItems.Count(),
            };
                
            return result;
        }
    }
}
