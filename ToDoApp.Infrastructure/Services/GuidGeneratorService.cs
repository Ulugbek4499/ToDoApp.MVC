using ToDoApp.Application.Commons.Interfaces;

namespace ToDoApp.Infrastructure.Services
{
    public class GuidGeneratorService : IGuidGenerator
    {
        public Guid Guid => Guid.NewGuid();
    }
}
