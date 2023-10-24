namespace BLL.Repositories.Interfaces
{
    using Models;

    public interface IToDoListRepository
    {
        Task<ToDoList> GetByIdAsync(int id);
        Task<IEnumerable<ToDoList>> GetAllAsync();
        Task AddAsync(ToDoList entity);
        Task UpdateAsync(ToDoList entity);
        Task DeleteAsync(int id);
    }
}