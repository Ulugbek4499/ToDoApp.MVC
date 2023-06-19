using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Entities
{
    public class ToDoList
    {
        public string Name { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
