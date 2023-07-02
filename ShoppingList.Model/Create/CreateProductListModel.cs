namespace ShoppingList.Model
{
    public class CreateProductListModel
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public List<string> ProductIds { get; set; }
    }
}
