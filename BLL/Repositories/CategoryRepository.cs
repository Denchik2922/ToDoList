namespace BLL.Repositories
{
    using BLL.Repositories.Interfaces;
    using DAL;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;

    public class CategoryRepository : ICategoryRepository
    {
        private ToDoListContext context;

        public CategoryRepository(ToDoListContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Category entity)
        {
            await this.context.AddAsync(entity).ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await this.GetByIdAsync(id).ConfigureAwait(false);

            context.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await this.context.Categories.Include(c => c.ToDoLists).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await this.context.Categories
                .Include(c => c.ToDoLists)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if (category is null)
            {
                throw new NullReferenceException($"{nameof(Category)} with id {id} not found");
            }

            return category;
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
