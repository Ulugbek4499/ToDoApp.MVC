using System.Text.Json.Serialization;
using ToDoApp.Domain.States;

namespace ToDoApp.Application.Commons.Models
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public ToDoItemStatus ToDoItemStatus { get; set; }
    }
}
