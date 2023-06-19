using System.Text.Json.Serialization;

namespace ToDoApp.Application.Commons.Models
{
    public class ToDoListDto
    {
        [JsonPropertyName("todolist_id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ToDoItemDto> ToDoItems { get; set; }
    }
}
