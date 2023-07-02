namespace ShoppingList.Model
{
    public class UpdateProductModel : ApiModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Bought { get; set; }
        public string CategoryId { get; set; }
    }
}
