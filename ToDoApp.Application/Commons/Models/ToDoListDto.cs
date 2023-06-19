using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

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
