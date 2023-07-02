using AutoMapper;
using ShoppingList.Common;
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

                cfg.CreateMap<CreateProductListModel, ProductList>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(
                    x => x.Products,
                    opts => opts
                    .MapFrom(x => x.ProductIds.Select(x => new Product
                    {
                        Id = x.ToGuid()
                    })
                ));

                cfg.CreateMap<UpdateProductListModel, ProductList>()
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.Id.ToGuid()))
                .ForMember(
                    x => x.Products,
                    opts => opts
                    .MapFrom(x => x.ProductIds.Select(x => new Product
                    {
                        Id = x.ToGuid()
                    })
                ));

                cfg.CreateMap<CreateProductCategoryModel, ProductCategory>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                    .ForMember(
                    x => x.Products,
                    opts => opts.Ignore()
                    );

                cfg.CreateMap<UpdateProductCategoryModel, ProductCategory>()
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.Id.ToGuid()))
                .ForMember(
                 x => x.Products,
                 opts => opts.Ignore()
                 );

                cfg.CreateMap<CreateProductModel, Product>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(
                 x => x.CategoryId,
                 opts => opts.MapFrom(x => x.CategoryId.ToGuid())
                 );

                cfg.CreateMap<UpdateProductModel, Product>()
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.Id.ToGuid()))
                .ForMember(
                 x => x.CategoryId,
                 opts => opts.MapFrom(x => x.CategoryId.ToGuid())
                 );

                cfg.CreateMap<CreateUserModel, User>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(
                 x => x.ProductLists,
                 opts => opts.MapFrom(x => x.ProductListIds.Select(x => new ProductList
                 {
                     Id = x.ToGuid()
                 })
                 ));

                cfg.CreateMap<UpdateUserModel, User>()
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.Id.ToGuid()))
                .ForMember(
                 x => x.ProductLists,
                 opts => opts.MapFrom(x => x.ProductListIds.Select(x => new ProductList
                 {
                     Id = x.ToGuid()
                 })
                 ));
            });
        }

        private static void CreateMap<TSource, TDestination>(IMapperConfigurationExpression config)
        {
            config.CreateMap<TSource, TDestination>();
            config.CreateMap<TDestination, TSource>();
        }
    }

}
