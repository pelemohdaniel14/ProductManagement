namespace ProductManagement.Dto.Category
{
    public class UpdateCategoryRequestModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
