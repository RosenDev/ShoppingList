namespace ShoppingList.Model
{
    public class CreateUserModel
    {
        public string Username { get; set; }
        public List<string> ProductListIds { get; set; }
    }
}
