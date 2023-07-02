namespace ShoppingList.Model
{
    public class UpdateUserModel : ApiModel
    {
        public string Username { get; set; }
        public List<string> ProductListIds { get; set; }
    }
}
