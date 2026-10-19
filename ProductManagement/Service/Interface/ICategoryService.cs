using ProductManagement.Dto.Category;

namespace ProductManagement.Service.Interface
{
    public interface ICategoryService
    {
        Task<CategoryResponseModel> GetByIdAsync(int id);
        Task<CategoryResponseModel> CreateAsync(CreateCategoryRequestModel model);
        Task<IEnumerable<CategoryResponseModel>> GetAllAsync();
        Task<CategoryResponseModel> UpadateAsync(UpdateCategoryRequestModel model);
        Task<CategoryResponseModel> Delete(int id);
    }
}
