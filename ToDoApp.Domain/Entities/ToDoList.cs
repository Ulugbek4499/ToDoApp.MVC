namespace ToDoApp.Domain.Entities
{
    public class ToDoList
    {
        public string Name { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
