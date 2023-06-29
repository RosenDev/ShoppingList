namespace ShoppingList.Data.Domain
{
    public class ProductCategory : Entity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}