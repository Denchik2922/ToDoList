namespace BLL.ControlOfTransactions
{
    using BLL.Repositories.Interfaces;

    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }

        IToDoListRepository ToDoListRepository { get; }

        Task CommitAsync();
        void Rollback();
    }
}