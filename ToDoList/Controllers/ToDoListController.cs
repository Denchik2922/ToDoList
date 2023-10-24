namespace ToDoList.Controllers
{
    using BLL.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        public IToDoListService toDoListService;

        public ToDoListController(IToDoListService toDoListService)
        {
            this.toDoListService = toDoListService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ToDoList>>> GetAll()
        {
            var categories = await this.toDoListService.GetAllToDoListAsync().ConfigureAwait(false);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoList>> GetById(int id)
        {
            var ToDoList = await this.toDoListService.GetToDoListByIdAsync(id).ConfigureAwait(false);
            return Ok(ToDoList);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ToDoList ToDoList)
        {
            await this.toDoListService.AddToDoListAsync(ToDoList).ConfigureAwait(false);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await this.toDoListService.DeleteToDoListAsync(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ToDoList ToDoList)
        {
            await this.toDoListService.UpdateToDoListAsync(ToDoList).ConfigureAwait(false);
            return Ok();
        }
    }
}
