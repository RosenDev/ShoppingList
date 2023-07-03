namespace ShoppingList.Data.Contracts
{
    public interface IDataSeeder
    {
        Task SeedDataAsync(CancellationToken ct);
    }
}
