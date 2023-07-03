using ShoppingList.Data.Contracts;
using ShoppingList.Data.Domain;

namespace ShoppingList.Data
{
    public class DataSeeder : IDataSeeder
    {
        private readonly ShoppingListDbContext shoppingListDbContext;

        public DataSeeder(ShoppingListDbContext shoppingListDbContext)
        {
            this.shoppingListDbContext = shoppingListDbContext;
        }

        public async Task SeedDataAsync(CancellationToken ct)
        {
            var productCategories = new List<ProductCategory>
            {
                new ProductCategory
                {
                    Name = "Food"
                },
                new ProductCategory
                {
                    Name = "Home"
                },new ProductCategory
                {
                    Name = "Computers"
                }
            };

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Bread",
                    Category = productCategories[0],
                     Price = 1.65
                },
                new Product
                {
                    Name = "Oranges",
                    Category = productCategories[0],
                    Price = 5
                },new Product
                {
                    Name = "Apple",
                    Category = productCategories[0],
                    Price = 2
                },
                new Product
                {
                    Name = "Table",
                    Category = productCategories[1],
                    Price = 150
                },
                new Product
                {
                    Name = "Macbook Pro 16 2019",
                    Category = productCategories[2],
                    Price = 5000
                },
            };

            shoppingListDbContext.Products.AddRange(products);
            await shoppingListDbContext.SaveChangesAsync(ct);
        }
    }
}
