using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.States;

namespace ToDoApp.Domain.Entities
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public ToDoItemStatus ToDoItemStatus { get; set; }
        public Guid ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }
    }
}
