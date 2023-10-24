namespace BLL.Repositories
{
    using BLL.Repositories.Interfaces;
    using DAL;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ToDoListRepository : IToDoListRepository
    {
        private ToDoListContext context;

        public ToDoListRepository(ToDoListContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(ToDoList entity)
        {
            await this.context.AddAsync(entity).ConfigureAwait(false);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await this.GetByIdAsync(id).ConfigureAwait(false);

            context.Remove(category);
        }

        public async Task<IEnumerable<ToDoList>> GetAllAsync()
        {
            return await this.context.ToDoLists.ToListAsync();
        }

        public async Task<ToDoList> GetByIdAsync(int id)
        {
            var category = await this.context.ToDoLists
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if (category is null)
            {
                throw new NullReferenceException($"{nameof(ToDoList)} with id {id} not found");
            }

            return category;
        }

        public Task UpdateAsync(ToDoList entity)
        {
            throw new NotImplementedException();
        }
    }
}