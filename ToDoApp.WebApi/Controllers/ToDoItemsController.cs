/*using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Application.UseCases.ToDoItems.Commands.CreateToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Commands.DeleteToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Commands.UpdateToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItem;
using ToDoApp.Application.UseCases.ToDoItems.Queries.GetToDoItems;

namespace ToDoApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ApiControllerBase
    {
        [HttpPost("[action]")]
        public async ValueTask<ActionResult<ToDoItemDto>> PostToDoItemAsync(CreateToDoItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<ToDoItemDto>> GetToDoItemAsync(Guid ToDoItemId)
        {
            return await Mediator.Send(new GetToDoItemQuery(ToDoItemId));
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<ToDoItemDto[]>> GetAllToDoItem()
        {
            return await Mediator.Send(new GetToDoItemsQuery());
        }


        [HttpPut("[action]")]
        public async ValueTask<ActionResult<ToDoItemDto>> UpdateToDoItemAsync(UpdateToDoItemCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpDelete("[action]")]
        public async ValueTask<ActionResult<ToDoItemDto>> DeleteToDoItemAsync(Guid ToDoItemId)
        {
            return await Mediator.Send(new DeleteToDoItemCommand(ToDoItemId));
        }
    }
}
*/