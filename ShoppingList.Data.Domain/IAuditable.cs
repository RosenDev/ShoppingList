namespace ShoppingList.Data.Domain
{
    public interface IAuditable
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}