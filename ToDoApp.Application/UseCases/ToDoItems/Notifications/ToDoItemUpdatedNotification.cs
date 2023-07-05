using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace ToDoApp.Application.UseCases.ToDoItems.Notifications
{
    public record ToDoItemUpdatedNotification(string UpdatedToDoItemTitle) : INotification;
    public class ToDoItemUpdatedNotificationHandler : INotificationHandler<ToDoItemUpdatedNotification>
    {
        public Task Handle(ToDoItemUpdatedNotification notification, CancellationToken cancellationToken)
        {

            Log.Information($"ToDoApp: Update ToDoItem notification " + $"Updated ToDoItem: {notification.UpdatedToDoItemTitle}");

            return Task.CompletedTask;
        }
    }
}
