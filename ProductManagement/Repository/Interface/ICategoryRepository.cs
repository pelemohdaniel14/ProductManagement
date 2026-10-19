using ProductManagement.Model;

namespace ProductManagement.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> AddAsync(Category model);
        Task<Category> UpdateAsync(Category model);
        Task DeleteAsync();
    }
}
