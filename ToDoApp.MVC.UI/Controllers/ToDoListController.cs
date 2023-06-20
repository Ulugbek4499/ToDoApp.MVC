﻿using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoLists.Commands.CreateToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Commands.DeleteToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Commands.UpdateToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Queries.GetToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Queries.GetToDoLists;

namespace ToDoApp.MVC.Controllers
{
    public class ToDoListController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateToDoList()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateToDoList([FromForm] CreateToDoListCommand ToDoList)
        {
            await Mediator.Send(ToDoList);

            return RedirectToAction("GetAllToDoLists");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllToDoLists()
        {
           ToDoListDto[] toDoLists =await Mediator.Send(new GetToDoListsQuery());

            return View(toDoLists);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewToDoList(Guid id)
        {
            var toDoList = await Mediator.Send(new GetToDoListQuery(id));
        
            return View("ViewToDoList", toDoList);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateToDoList(ToDoListDto toDoListDto)
        {
          return  View(toDoListDto);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateToDoList([FromForm] UpdateToDoListCommand toDoList)
        {
            await Mediator.Send(toDoList);
            return RedirectToAction("GetAllToDoLists");
        }

        public async ValueTask<IActionResult> DeleteToDoList(Guid Id)
        {
            await Mediator.Send(new DeleteToDoListCommand(Id));

            return RedirectToAction("GetAllToDoLists");
        }
    }
}
