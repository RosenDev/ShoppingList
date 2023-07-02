namespace ShoppingList.Data.Domain
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}