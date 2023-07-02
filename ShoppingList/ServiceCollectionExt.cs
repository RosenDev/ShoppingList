using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingList.CommandsAndQueries.ProductCategories.Commands;
using ShoppingList.Data;
using ShoppingList.Data.Repositories;
using ShoppingList.Data.Repositories.Contracts;
using ShoppingList.Services;
using ShoppingList.Services.Contracts;

namespace ShoppingList
{
    public static class ServiceCollectionExt
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CreateProductCategoryCommand).Assembly));
            services.AddAutoMapper();
            services.AddDbContext<ShoppingListDbContext>(opts =>
            {
                opts.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    x => x.EnableRetryOnFailure()
                    );
            });
            services.AddTransient<IProductCategoriesService, ProductCategoriesService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IProductListsService, ProductListsService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductRepository, ProductReposiotry>();
            services.AddTransient<IProductListRepository, ProductListRepository>();
            services.AddTransient<IUserRepository, UserReposiotry>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(context => MapperInitializer.GetMappings());

            services.AddSingleton(sp =>
            {
                var config = sp.GetService<MapperConfiguration>();
                return config.CreateMapper(sp.GetService);
            });

            return services;
        }
    }
}
