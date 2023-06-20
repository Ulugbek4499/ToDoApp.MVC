using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItems;
using ToDoApp.Domain.Entities;

namespace ToDoApp.MVC.Controllers
{
    public class ToDoListController : ApiBaseController
    {
       public async ValueTask<IActionResult> GetAllToDoLists()
       {
            var toDoLists = Mediator.Send(new GetToDoItemsQuery());
            
            return View(toDoLists);
       }


    }
}
