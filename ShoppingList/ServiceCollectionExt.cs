using AutoMapper;
using ShoppingList.CommandsAndQueries.Commands;
using ShoppingList.Services;

namespace ShoppingList
{
    public static class ServiceCollectionExt
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CreateProductCategoryCommand).Assembly));
            services.AddAutoMapper();

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
