using AutoMapper;
using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Services
{
    public class MapperInitializer
    {
        public static MapperConfiguration GetMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                CreateMap<User, UserModel>(cfg);
                CreateMap<ProductCategory, ProductCategoryModel>(cfg);
                CreateMap<Product, ProductModel>(cfg);
                CreateMap<ProductList, ProductListModel>(cfg);
            });
        }

        private static void CreateMap<TSource, TDestination>(IMapperConfigurationExpression config)
        {
            config.CreateMap<TSource, TDestination>();
            config.CreateMap<TDestination, TSource>();
        }
    }

}
