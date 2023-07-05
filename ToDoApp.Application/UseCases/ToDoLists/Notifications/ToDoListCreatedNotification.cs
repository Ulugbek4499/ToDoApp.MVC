using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace ToDoApp.Application.UseCases.ToDoLists.Notifications
{
    public record ToDoListCreatedNotification(string name) : INotification;

    public class ToDoListCreatedNotificationHandler : INotificationHandler<ToDoListCreatedNotification>
    {
        public Task Handle(ToDoListCreatedNotification notification, CancellationToken cancellationToken)
        {
            Log.Information($"ToDoApp: New ToDoList created with {notification.name} name.");

            return Task.CompletedTask;
        }
    }
}
