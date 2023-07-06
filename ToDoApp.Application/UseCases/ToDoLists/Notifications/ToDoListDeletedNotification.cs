using MediatR;
using Serilog;

namespace ToDoApp.Application.UseCases.ToDoLists.Notifications
{
    public record ToDoListDeletedNotification(string name) : INotification;

    public class ToDoListDeletedNotificationHandler : INotificationHandler<ToDoListDeletedNotification>
    {
        public Task Handle(ToDoListDeletedNotification notification, CancellationToken cancellationToken)
        {
            Log.Information($"ToDoApp: ToDoList with {notification.name} name deleted.");

            return Task.CompletedTask;
        }
    }
}
