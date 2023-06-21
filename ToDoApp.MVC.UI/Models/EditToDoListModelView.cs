using System.ComponentModel.DataAnnotations;

namespace ToDoApp.MVC.UI.Models
{
    public class EditToDoListModelView
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
