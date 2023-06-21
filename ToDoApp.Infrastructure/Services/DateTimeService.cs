using ToDoApp.Application.Commons.Interfaces;

namespace ToDoApp.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
