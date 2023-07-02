namespace ShoppingList.Data.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Bought { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}