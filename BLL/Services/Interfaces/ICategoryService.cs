namespace BLL.Services.Interfaces
{
    using Models;

    public interface ICategoryService
    {
        Task<Category> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Category>> GetCategoryAllAsync();
        Task AddCategoryAsync(Category entity);
        Task UpdateCategoryAsync(Category entity);
        Task DeleteCategoryAsync(int id);
    }
}