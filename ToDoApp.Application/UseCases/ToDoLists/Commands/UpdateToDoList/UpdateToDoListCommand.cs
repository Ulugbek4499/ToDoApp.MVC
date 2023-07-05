﻿using AutoMapper;
using MediatR;
using ToDoApp.Application.Commons.Exceptions;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoLists.Notifications;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.UseCases.ToDoLists.Commands.UpdateToDoList
{
    public class UpdateToDoListCommand : IRequest<ToDoListDto>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public class UpdateToDoListCommandHandler : IRequestHandler<UpdateToDoListCommand, ToDoListDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateToDoListCommandHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ToDoListDto> Handle(UpdateToDoListCommand request, CancellationToken cancellationToken)
        {
            ToDoList? maybeToDoList = await _context.ToDoLists
                .FindAsync(new object[] { request.Id }, cancellationToken);

            ValidateToDoListIsNotNull(request, maybeToDoList);

            maybeToDoList.Name = request.Name;

            maybeToDoList = _context.ToDoLists.Update(maybeToDoList).Entity;

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ToDoListUpdatedNotification(maybeToDoList.Name));

            return _mapper.Map<ToDoListDto>(maybeToDoList);
        }

        private static void ValidateToDoListIsNotNull(UpdateToDoListCommand request, ToDoList? maybeToDoList)
        {
            if (maybeToDoList is null)
            {
                throw new NotFoundException(nameof(ToDoList), request.Id);
            }
        }
    }
}
