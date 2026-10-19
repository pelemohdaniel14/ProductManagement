namespace ProductManagement.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public int AmountOfProduct { get; set; }
        public decimal Amount { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category{ get; set; }

    }
}
