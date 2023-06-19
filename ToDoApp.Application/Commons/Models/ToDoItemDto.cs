using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.States;

namespace ToDoApp.Application.Commons.Models
{
    public class ToDoItemDto
    {
        [JsonPropertyName("todoitem_id")]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public ToDoItemStatus ToDoItemStatus { get; set; }
    }
}
