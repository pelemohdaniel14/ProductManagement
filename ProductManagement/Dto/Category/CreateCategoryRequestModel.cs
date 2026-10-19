namespace ProductManagement.Dto.Category
{
    public class CreateCategoryRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
