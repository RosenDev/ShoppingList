namespace ShoppingList.Data.Domain
{
    public interface IDeleteable
    {
        bool IsDeleted { get; set; }
        DateTime? Deleted { get; set; }
    }
}