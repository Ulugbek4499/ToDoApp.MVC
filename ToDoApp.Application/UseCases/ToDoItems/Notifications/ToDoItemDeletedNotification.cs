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
