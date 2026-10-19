namespace ProductManagement.Model
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Product> Product { get; set; }
    }
}
