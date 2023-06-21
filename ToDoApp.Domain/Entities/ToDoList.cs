using ToDoApp.Domain.Common;

namespace ToDoApp.Domain.Entities
{
    public class ToDoList : BaseAuditableEntity
    {
        public string Name { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
