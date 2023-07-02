namespace ShoppingList.Model
{
    public class ProductListModel : ApiModel
    {
        public string Name { get; set; }

        public UserModel User { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
