using Microsoft.EntityFrameworkCore;
using ProductManagement.Context;
using ProductManagement.Model;
using ProductManagement.Repository.Interface;

namespace ProductManagement.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository (ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Product> AddAsync(Product model)
        {
            var product = await _db.Products.AddAsync(model);
            await _db.SaveChangesAsync();
            return product.Entity;
        }

        public async Task DeleteAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.Include(p => p.Category).Where(p => p.IsDeleted == false).ToListAsync(); 
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.Products.SingleOrDefaultAsync(p => p.Id == id && p.IsDeleted == false);
        }

        public async Task<Product> UpdateAsync(Product model)
        {
           var product = _db.Products.Update(model);
            await _db.SaveChangesAsync();
            return product.Entity;
        }
    }
}
