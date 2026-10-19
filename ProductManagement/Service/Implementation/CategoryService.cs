using ProductManagement.Dto.Category;
using ProductManagement.Model;
using ProductManagement.Repository.Interface;
using ProductManagement.Service.Interface;

namespace ProductManagement.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryResponseModel> CreateAsync(CreateCategoryRequestModel model)
        {
            var category = new Category
            {
                Name = model.Name,
                Description = model.Description,
                CreatedBy = "Balkiz",
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };
            var categoryEntity = await _categoryRepository.AddAsync(category);
             return ReturnCategoryResponseModel(categoryEntity);
        }

        public async Task<CategoryResponseModel> Delete(int id)
        {
           var category =  await _categoryRepository.GetByIdAsync(id);
            category.IsDeleted = true;
            await _categoryRepository.DeleteAsync();
            return ReturnCategoryResponseModel(category);
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAllAsync()
        {
           var categories = await _categoryRepository.GetAllAsync();

            return  categories.Select(x => ReturnCategoryResponseModel(x)).ToList();
        }

        public async Task<CategoryResponseModel> GetByIdAsync(int id)
        {
            return ReturnCategoryResponseModel(await _categoryRepository.GetByIdAsync(id));
        }

        public async Task<CategoryResponseModel> UpadateAsync(UpdateCategoryRequestModel model)
        {
            var category = await _categoryRepository.GetByIdAsync(model.CategoryId);
            category.Name = !string.IsNullOrEmpty(model.Name) && model.Name != category.Name ? model.Name : category.Name;
            category.Description = !string.IsNullOrEmpty(model.Description) && model.Description != category.Description ? model.Description : category.Description;
            category.UpdatedBy = "Balkiz";
            category.UpdatedAt = DateTime.UtcNow;
            var returnedEntity = await _categoryRepository.UpdateAsync(category);
            if (returnedEntity == null) return null;
            return ReturnCategoryResponseModel(returnedEntity);
        }


        private CategoryResponseModel ReturnCategoryResponseModel(Category model)
        {
            return new CategoryResponseModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                IsDeleted = model.IsDeleted
            };
        }
    }
}
