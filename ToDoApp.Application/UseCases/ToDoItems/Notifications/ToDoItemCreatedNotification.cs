using MediatR;
using Serilog;

namespace ToDoApp.Application.UseCases.ToDoItems.Notifications
{
    public record ToDoItemCreatedNotification(string title) : INotification;

    public class ToDoItemCreatedLogNotificationHandler : INotificationHandler<ToDoItemCreatedNotification>
    {
        public Task Handle(ToDoItemCreatedNotification notification, CancellationToken cancellationToken)
        {
            Log.Information($"ToDoApp: New ToDoItem created with {notification.title} title.");

            return Task.CompletedTask;
        }
    }

    public class ToDoItemCreatedConsoleNotificationHandler : INotificationHandler<ToDoItemCreatedNotification>
    {
        public async Task Handle(ToDoItemCreatedNotification notification, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync($"ToDoApp: New ToDoItem created with {notification.title} title.");
        }
    }
}
