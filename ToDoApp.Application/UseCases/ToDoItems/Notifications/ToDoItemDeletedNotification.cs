using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace ToDoApp.Application.UseCases.ToDoItems.Notifications
{
    public record ToDoItemDeletedNotification(string name) : INotification;

    public class ToDoItemDeletedNotificationHandler : INotificationHandler<ToDoItemDeletedNotification>
    {
        public Task Handle(ToDoItemDeletedNotification notification, CancellationToken cancellationToken)
        {
            Log.Information($"ToDoApp: ToDoItem with {notification.name} name deleted.");

            return Task.CompletedTask;
        }
    }
}
