﻿using AutoMapper;
using MediatR;
using ToDoApp.Application.Commons.Exceptions;
using ToDoApp.Application.Commons.Interfaces;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.States;

namespace ToDoApp.Application.UseCases.ToDoItems.Commands.UpdateToDoItem
{
    public class UpdateToDoItemCommand:IRequest<ToDoItemDto>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public ToDoItemStatus ToDoItemStatus { get; set; }
        public Guid ToDoListId { get; set; }
    }

    public class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand, ToDoItemDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateToDoItemCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToDoItemDto> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            ToDoItem maybeToDoItem = await
                 _context.ToDoItems.FindAsync(new object[] { request.Id });

            ValidateToDoItemIsNotNull(request, maybeToDoItem);

            ToDoList? maybeToDoList = await
             _context.ToDoLists.FindAsync(new object[] { request.ToDoListId });

            ValidateToDoListIsNotNull(request, maybeToDoList);

            maybeToDoItem.Title = request.Title;
            maybeToDoItem.Description = request.Description;
            maybeToDoItem.DueDate=request.DueDate;
            maybeToDoItem.ToDoItemStatus=request.ToDoItemStatus;
            maybeToDoItem.ToDoList = maybeToDoList;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ToDoItemDto>(maybeToDoItem);
        }

        private void ValidateToDoItemIsNotNull(UpdateToDoItemCommand request, ToDoItem? maybeToDoItem)
        {
            if (maybeToDoItem is null)
            {
                throw new NotFoundException(nameof(ToDoItem), request.Id);
            }
        }
        private void ValidateToDoListIsNotNull(UpdateToDoItemCommand request, ToDoList? maybeToDoList)
        {
            if (maybeToDoList is null)
            {
                throw new NotFoundException(nameof(ToDoList), request.ToDoListId);
            }
        }
    }
}
