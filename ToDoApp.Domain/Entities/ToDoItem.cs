using ToDoApp.Domain.States;

namespace ToDoApp.Domain.Entities
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public ToDoItemStatus ToDoItemStatus { get; set; }
        public Guid ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }
    }
}
