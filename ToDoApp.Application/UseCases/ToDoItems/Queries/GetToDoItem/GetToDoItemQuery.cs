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

namespace ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItem
{
    public record GetToDoItemQuery(Guid ToDoItemId) : IRequest<ToDoItemDto>;

    public class GetToDoItemQueryHandler : IRequestHandler<GetToDoItemQuery, ToDoItemDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetToDoItemQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto> Handle(GetToDoItemQuery request, CancellationToken cancellationToken)
        {
            ToDoItem maybeToDoItem = await
                _context.ToDoItems.FindAsync(new object[] { request.ToDoItemId });

            ValidateToDoItemIsNotNull(request, maybeToDoItem);

            return _mapper.Map<ToDoItemDto>(maybeToDoItem);
        }

        private void ValidateToDoItemIsNotNull(GetToDoItemQuery request, ToDoItem? maybeToDoItem)
        {
            if (maybeToDoItem is null)
            {
                throw new NotFoundException(nameof(ToDoItem), request.ToDoItemId);
            }
        }
    }
}
