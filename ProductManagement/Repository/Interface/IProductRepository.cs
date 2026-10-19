using ProductManagement.Model;

namespace ProductManagement.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product model);
        Task<Product> UpdateAsync(Product model);
        Task DeleteAsync();
    }
}
