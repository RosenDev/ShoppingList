namespace ShoppingList.Model
{
    public class UpdateProductListModel : ApiModel
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public List<string> ProductIds { get; set; }
    }
}
