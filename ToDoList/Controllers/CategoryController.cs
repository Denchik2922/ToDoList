namespace ToDoList.Controllers
{
    using BLL.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Category>>> GetAll()
        {
            var categories = await this.categoryService.GetCategoryAllAsync().ConfigureAwait(false);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await this.categoryService.GetCategoryByIdAsync(id).ConfigureAwait(false);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Category category)
        {
            await this.categoryService.AddCategoryAsync(category).ConfigureAwait(false);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await this.categoryService.DeleteCategoryAsync(id).ConfigureAwait(false);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Category category)
        {
            await this.categoryService.UpdateCategoryAsync(category).ConfigureAwait(false);
            return Ok();
        }
    }
}