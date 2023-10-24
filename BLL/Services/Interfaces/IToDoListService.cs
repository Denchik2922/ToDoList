namespace BLL.Services.Interfaces
{
    using Models;

    public interface IToDoListService
    {
        Task<ToDoList> GetToDoListByIdAsync(int id);
        Task<IEnumerable<ToDoList>> GetAllToDoListAsync();
        Task AddToDoListAsync(ToDoList entity);
        Task UpdateToDoListAsync(ToDoList entity);
        Task DeleteToDoListAsync(int id);
    }
}