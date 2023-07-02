namespace ShoppingList.Data.Domain
{
    public interface IEntity : IAuditable, IDeleteable
    {
        public Guid Id { get; set; }
    }
}