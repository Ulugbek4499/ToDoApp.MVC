using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace ToDoApp.Application.UseCases.ToDoLists.Notifications
{
    public record ToDoListUpdatedNotification(string UpdatedToDoListName) : INotification;
    public class ToDoListUpdatedNotificationHandler : INotificationHandler<ToDoListUpdatedNotification>
    {
        public Task Handle(ToDoListUpdatedNotification notification, CancellationToken cancellationToken)
        {

            Log.Information($"ToDoApp: Update ToDoList notification " + $"Updated ToDoList: {notification.UpdatedToDoListName}");

            return Task.CompletedTask;
        }
    }
}
