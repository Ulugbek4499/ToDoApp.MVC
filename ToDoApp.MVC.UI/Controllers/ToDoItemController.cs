using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoItems.Commands.CreateToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Commands.DeleteToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Commands.UpdateToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItems;
using ToDoApp.Application.UseCases.ToDoLists.Commands.UpdateToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Queries.GetToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Queries.GetToDoLists;
using ToDoApp.MVC.Controllers;

namespace ToDoApp.MVC.UI.Controllers
{
    public class ToDoItemController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateToDoItem()
        {
            ToDoListDto[] toDoLists = await Mediator.Send(new GetToDoListsQuery());
            ViewData["ToDoLists"] = toDoLists;
            return View();
        }


        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateToDoItem([FromForm] CreateToDoItemCommand toDoItem)
        {
            await Mediator.Send(toDoItem);
            return RedirectToAction("GetAllToDoItems");
        }


        [HttpGet("[action]")]
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

        [HttpGet]
        public async ValueTask<IActionResult> UpdateToDoItem(Guid Id)
        {
            var toDoItem = await Mediator.Send(new GetToDoItemQuery(Id));

            return View(toDoItem);
        }

        [HttpPost]
        public async ValueTask<IActionResult> UpdateToDoItem([FromForm] UpdateToDoItemCommand ToDoItem)
        {
            await Mediator.Send(ToDoItem);
            return RedirectToAction("GetAllToDoItems");
        }

        public async ValueTask<IActionResult> DeleteToDoItem(Guid Id)
        {
            await Mediator.Send(new DeleteToDoItemCommand(Id));

            return RedirectToAction("GetAllToDoItems");
        }
    }
}
