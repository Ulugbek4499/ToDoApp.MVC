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
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItems
{
    public record GetToDoItemsQuery : IRequest<ToDoItemDto[]>;

    public class GetToDoItemsQueryHandler : IRequestHandler<GetToDoItemsQuery, ToDoItemDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetToDoItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto[]> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
        {
            ToDoItem[] ToDoItems = await _context.ToDoItems.ToArrayAsync();

            return _mapper.Map<ToDoItemDto[]>(ToDoItems);
        }
    }
}
