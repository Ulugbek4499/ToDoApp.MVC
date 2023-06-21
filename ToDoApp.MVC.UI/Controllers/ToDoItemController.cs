using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoItems.Commands.CreateToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Commands.DeleteToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItems;
using ToDoApp.MVC.Controllers;

namespace ToDoApp.MVC.UI.Controllers
{
    public class ToDoItemController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateToDoItem()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateToDoItem([FromForm] CreateToDoItemCommand ToDoItem)
        {
            await Mediator.Send(ToDoItem);

            return RedirectToAction("GetAllToDoItems");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllToDoItems()
        {
            ToDoItemDto[] toDoItems = await Mediator.Send(new GetToDoItemsQuery());

            return View(toDoItems);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewToDoItem(Guid id)
        {
            var toDoItem = await Mediator.Send(new GetToDoItemQuery(id));

            return View("ViewToDoItem", toDoItem);
        }

        public async ValueTask<IActionResult> DeleteToDoItem(Guid Id)
        {
            await Mediator.Send(new DeleteToDoItemCommand(Id));

            return RedirectToAction("GetAllToDoItems");
        }
    }
}
