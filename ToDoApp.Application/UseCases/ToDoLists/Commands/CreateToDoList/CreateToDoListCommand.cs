using AutoMapper;
using MediatR;
using ToDoApp.Application.Commons.Exceptions;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UseCases.ToDoLists.Commands.CreateToDoList
{
    public class CreateToDoListCommand : IRequest<ToDoListDto>
    {
        public string Name { get; set; }
    }

    public class CreateToDoListCommandHandler : IRequestHandler<CreateToDoListCommand, ToDoListDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateToDoListCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoListDto> Handle(CreateToDoListCommand request, CancellationToken cancellationToken)
        {
            ToDoList maybeToDoList =
                _context.ToDoLists.SingleOrDefault(d => d.Name.Equals(request.Name));

            ValidateToDoListIsNull(request, maybeToDoList);

            var ToDoList = new ToDoList()
            {
                Name = request.Name,
            };

            maybeToDoList = _context.ToDoLists.Add(ToDoList).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ToDoListDto>(maybeToDoList);
        }

        private static void ValidateToDoListIsNull(CreateToDoListCommand request, ToDoList? maybeToDoList)
        {
            if (maybeToDoList != null)
            {
                throw new AlreadyExistsException(nameof(ToDoList), request.Name);
            }
        }
    }
}
