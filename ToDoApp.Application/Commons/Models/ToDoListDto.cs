namespace ToDoApp.Application.Commons.Models
{
    public class ToDoListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ToDoItemDto> ToDoItems { get; set; }
    }
}
