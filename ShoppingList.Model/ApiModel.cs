namespace ShoppingList.Model
{
    public class ApiModel : IApiEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
