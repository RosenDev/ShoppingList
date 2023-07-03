namespace ShoppingList.Data.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}