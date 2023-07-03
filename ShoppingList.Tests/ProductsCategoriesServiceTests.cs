using Moq;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.Tests;

public class ProductsCategoriesServiceTests
{
    [Fact]
    public async Task ProductCategoriesService_ListAsync_ShouldReturnProductCategories_WhenThereIsData()
    {
        var productCategoriesServiceMock = new Mock<IProductCategoriesService>();
        var testProductCategory = new ProductCategoryModel
        {
            Name = "Test category",

        };
        var testData = new List<ProductCategoryModel> { testProductCategory };
        productCategoriesServiceMock.Setup(x => x.ListAsync(It.IsAny<Paging>(), default))
            .ReturnsAsync(() => new PagedResponse<ProductCategoryModel>(testData, 1, 1, 1));

        var productCategoriesService = productCategoriesServiceMock.Object;

        Assert.Equal(testData.Count, (await productCategoriesService.ListAsync(new Paging(), default)).Result.Count);
    }

    [Fact]
    public async Task ProductCategoriesService_QueryAsync_ShouldNotReturnProductCategories_WhenThereIsNoData()
    {
        var productCategoriesServiceMock = new Mock<IProductCategoriesService>();

        var testData = new List<ProductCategoryModel>();
        productCategoriesServiceMock.Setup(x => x.ListAsync(It.IsAny<Paging>(), default))
           .ReturnsAsync(() => new PagedResponse<ProductCategoryModel>(testData, 1, 1, 1));

        var productCategoriesService = productCategoriesServiceMock.Object;

        Assert.Empty((await productCategoriesService.ListAsync(new Paging(), default)).Result);
    }

    [Fact]
    public async Task ProductCategoriesService_GetByIdAsync_ShouldReturnNull_WhenProductCategoryDoesNotExists()
    {
        var productCategoriesServiceMock = new Mock<IProductCategoriesService>();

        productCategoriesServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), default))
            .ReturnsAsync(() => null);

        var productCategoriesService = productCategoriesServiceMock.Object;

        Assert.Null(await productCategoriesService.GetByIdAsync(Guid.NewGuid(), default));
    }

    [Fact]
    public async Task ProductCategoriesService_UpdateProductCategoryAsync_ShouldReturnProductCategoryId_WhenProductCategoryExists()
    {
        var productCategoriesServiceMock = new Mock<IProductCategoriesService>();
        var id = Guid.NewGuid();
        var testProductCategory = new ProductCategoryModel
        {
            Id = id.ToString(),
            Name = "Test category"
        };

        productCategoriesServiceMock.Setup(x => x.UpdateAsync(It.Is<UpdateProductCategoryModel>(x => x.Id == testProductCategory.Id), default))
            .ReturnsAsync(() => testProductCategory.Id);

        var productCategoriesService = productCategoriesServiceMock.Object;

        Assert.Equal(testProductCategory.Id, await productCategoriesService.UpdateAsync(new UpdateProductCategoryModel { Id = id.ToString(), Name = "Test updated" }, default));
    }

    [Fact]
    public async Task ProductCategoriesService_DeleteAsync_ShouldReturnFalse_WhenProductCategoryDoesNotExists()
    {
        var productCategoriesServiceMock = new Mock<IProductsService>();

        productCategoriesServiceMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>(), default))
            .ReturnsAsync(() => false);

        var productCategoriesService = productCategoriesServiceMock.Object;

        Assert.False(await productCategoriesService.DeleteAsync(Guid.NewGuid(), default));
    }
}
