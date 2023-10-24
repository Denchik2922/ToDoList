namespace BLL.Services
{
    using BLL.ControlOfTransactions;
    using BLL.Services.Interfaces;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        public IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddCategoryAsync(Category entity)
        {
            try
            {
                await this.unitOfWork.CategoryRepository.AddAsync(entity).ConfigureAwait(false);
                await unitOfWork.CommitAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            try
            {
                await this.unitOfWork.CategoryRepository.DeleteAsync(id).ConfigureAwait(false);
                await unitOfWork.CommitAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetCategoryAllAsync()
        {
            return await this.unitOfWork.CategoryRepository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await this.unitOfWork.CategoryRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task UpdateCategoryAsync(Category entity)
        {
            try
            {
                await this.unitOfWork.CategoryRepository.UpdateAsync(entity).ConfigureAwait(false);
                await unitOfWork.CommitAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
