using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItems;
using ToDoApp.MVC.Controllers;

namespace ToDoApp.MVC.UI.Controllers
{
    public class ToDoItemController:ApiBaseController
    {
        [HttpGet]
        public async ValueTask<IActionResult> GetAllToDoItems()
        {
            ToDoItemDto[] toDoItems =await Mediator.Send(new GetToDoItemsQuery());

            return View(toDoItems);
        }
    }
}
