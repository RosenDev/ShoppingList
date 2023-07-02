namespace ShoppingList.Data.Domain
{
    public class ProductList : Entity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
