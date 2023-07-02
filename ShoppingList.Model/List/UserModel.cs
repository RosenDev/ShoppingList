namespace ShoppingList.Model
{
    public class UserModel : ApiModel
    {
        public string Username { get; set; }
        public List<ProductListModel> ProductLists { get; set; }
    }
}
