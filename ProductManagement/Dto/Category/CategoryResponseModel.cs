using ProductManagement.Model;

namespace ProductManagement.Dto.Category
{
    public class CategoryResponseModel
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Product> Product { get; set; }
    }
}
