using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ToDoApp.Application.Commons.Exceptions;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UseCases.ToDoLists.Queries.GetToDoList
{
    public record GetToDoListQuery(Guid ToDoListId) : IRequest<ToDoListDto>;

    public class GetToDoListQueryHandler : IRequestHandler<GetToDoListQuery, ToDoListDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetToDoListQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoListDto> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            ToDoList maybeToDoList = await _context.ToDoLists
                .FindAsync(new object[] { request.ToDoListId });

            ValidateToDoListIsNotNull(request, maybeToDoList);

            return _mapper.Map<ToDoListDto>(maybeToDoList);
        }

        private static void ValidateToDoListIsNotNull(GetToDoListQuery request, ToDoList maybeToDoList)
        {
            if (maybeToDoList == null)
            {
                throw new NotFoundException(nameof(ToDoList), request.ToDoListId);
            }
        }
    }
}
