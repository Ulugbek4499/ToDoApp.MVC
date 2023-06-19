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

namespace ToDoApp.Application.UseCases.ToDoLists.Queries.GetToDoLists
{
    public record GetToDoListsQuery : IRequest<ToDoListDto[]>;

    public class GetToDoListsQueryHandler : IRequestHandler<GetToDoListsQuery, ToDoListDto[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetToDoListsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoListDto[]> Handle(GetToDoListsQuery request, CancellationToken cancellationToken)
        {
            ToDoList[] ToDoLists = await _context.ToDoLists.ToArrayAsync();

            return _mapper.Map<ToDoListDto[]>(ToDoLists);
        }
    }
}
