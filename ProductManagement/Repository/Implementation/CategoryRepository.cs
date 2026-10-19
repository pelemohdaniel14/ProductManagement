using Microsoft.EntityFrameworkCore;
using ProductManagement.Context;
using ProductManagement.Model;
using ProductManagement.Repository.Interface;

namespace ProductManagement.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> AddAsync(Category model)
        {
            var category = await _db.Categories.AddAsync(model);
            await _db.SaveChangesAsync();
            return category.Entity;
        }

        public async Task DeleteAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Categories.Where(c => c.IsDeleted == false).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _db.Categories.FirstOrDefaultAsync(c => c.Id == id && c.IsDeleted == false);
        }

        public async Task<Category> UpdateAsync(Category model)
        {
            var category = _db.Categories.Update(model);
            await _db.SaveChangesAsync();
            return category.Entity;
        }
    }
}
