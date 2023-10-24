namespace BLL.ControlOfTransactions
{
    using BLL.Repositories;
    using BLL.Repositories.Interfaces;
    using DAL;
    using Microsoft.EntityFrameworkCore;

    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly ToDoListContext context;

        private ICategoryRepository categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository is null)
                {
                    categoryRepository = new CategoryRepository(context);
                }
                return categoryRepository;
            }
        }

        private IToDoListRepository toDoListRepository;
        public IToDoListRepository ToDoListRepository
        {
            get
            {
                if (toDoListRepository is null)
                {
                    toDoListRepository = new ToDoListRepository(context);
                }
                return toDoListRepository;
            }
        }

        public UnitOfWork(ToDoListContext context)
        {
            this.context = context;
        }

        public async Task CommitAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Rollback()
        {
            foreach (var entry in this.context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}