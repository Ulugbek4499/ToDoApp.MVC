using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoLists.Commands.CreateToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Commands.DeleteToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Commands.UpdateToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Queries.GetToDoList;
using ToDoApp.Application.UseCases.ToDoLists.Queries.GetToDoLists;

namespace ToDoApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ApiControllerBase
    {
        [HttpPost("[action]")]
        public async ValueTask<ActionResult<ToDoListDto>> PostToDoListAsync(CreateToDoListCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<ToDoListDto>> GetToDoListAsync(Guid ToDoListId)
        {
            return await Mediator.Send(new GetToDoListQuery(ToDoListId));
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<ToDoListDto[]>> GetAllToDoList()
        {
            return await Mediator.Send(new GetToDoListsQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<ActionResult<ToDoListDto>> UpdateToDoListAsync(UpdateToDoListCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpDelete("[action]")]
        public async ValueTask<ActionResult<ToDoListDto>> DeleteToDoListAsync(Guid ToDoListId)
        {
            return await Mediator.Send(new DeleteToDoListCommand(ToDoListId));
        }
    }
}
