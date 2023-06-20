using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoLists.Queries.GetToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Queries.GetToDoLists;
using ToDoApp.Domain.Entities;

namespace ToDoApp.MVC.Controllers
{
    public class ToDoListController : ApiBaseController
    {
        [HttpGet]
        public async ValueTask<IActionResult> GetAllToDoLists()
        {
           ToDoListDto[] toDoLists =await Mediator.Send(new GetToDoListsQuery());

            return View(toDoLists);
        }

        [HttpGet]
        public async ValueTask<IActionResult> ViewToDoList(Guid id)
        {
            var toDoList = await Mediator.Send(new GetToDoListQuery(id));

            return View("ViewToDoList", toDoList);
        }

    }
}
