namespace BLL.Services
{
    using BLL.ControlOfTransactions;
    using BLL.Services.Interfaces;
    using Models;


    public class ToDoListService : IToDoListService
    {
        public IUnitOfWork unitOfWork;

        public ToDoListService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task AddToDoListAsync(ToDoList entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoListAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoList>> GetAllToDoListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ToDoList> GetToDoListByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateToDoListAsync(ToDoList entity)
        {
            throw new NotImplementedException();
        }
    }
}
