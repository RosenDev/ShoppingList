namespace ShoppingList.Data.Domain
{
    public interface IAuditable
    {
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}