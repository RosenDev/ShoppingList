namespace ShoppingList.Data.Domain
{
    public class User : Entity
    {
        public string Username { get; set; }

        public List<ProductList> ProductLists { get; set; }
    }
}
