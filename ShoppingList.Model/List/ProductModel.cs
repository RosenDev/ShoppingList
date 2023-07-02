namespace ShoppingList.Model
{
    public class ProductModel : ApiModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Bought { get; set; }
        public ProductCategoryModel Category { get; set; }
    }
}
