using Moq;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.Tests;

public class ProductsServiceTests
{
    [Fact]
    public async Task ProductService_ListAsync_ShouldReturnProducts_WhenThereIsData()
    {
        var productsServiceMock = new Mock<IProductsService>();
        var testProduct = new ProductModel
        {
            Name = "Test product",
            Price = 1,
        };
        var testData = new List<ProductModel> { testProduct };
        productsServiceMock.Setup(x => x.ListAsync(It.IsAny<Paging>(), default))
            .ReturnsAsync(() => new PagedResponse<ProductModel>(testData, 1, 1, 1));

        var productsService = productsServiceMock.Object;

        Assert.Equal(testData.Count, (await productsService.ListAsync(new Paging(), default)).Result.Count);
    }

    [Fact]
    public async Task ProductService_QueryAsync_ShouldNotReturnProducts_WhenThereIsNoData()
    {
        var productServiceMock = new Mock<IProductsService>();

        var testData = new List<ProductModel>();
        productServiceMock.Setup(x => x.ListAsync(It.IsAny<Paging>(), default))
           .ReturnsAsync(() => new PagedResponse<ProductModel>(testData, 1, 1, 1));

        var productService = productServiceMock.Object;

        Assert.Empty((await productService.ListAsync(new Paging(), default)).Result);
    }

    [Fact]
    public async Task ProductService_GetByIdAsync_ShouldReturnNull_WhenProductDoesNotExists()
    {
        var productsServiceMock = new Mock<IProductsService>();

        productsServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), default))
            .ReturnsAsync(() => null);

        var productService = productsServiceMock.Object;

        Assert.Null(await productService.GetByIdAsync(Guid.NewGuid(), default));
    }

    [Fact]
    public async Task ProductService_UpdateProductAsync_ShouldReturnProductId_WhenProductExists()
    {
        var productServiceMock = new Mock<IProductsService>();
        var id = Guid.NewGuid();
        var testProduct = new ProductModel
        {
            Id = id.ToString(),
            Name = "Test product",
            Price = 1,
        };

        productServiceMock.Setup(x => x.UpdateAsync(It.Is<UpdateProductModel>(x => x.Id == testProduct.Id), default))
            .ReturnsAsync(() => testProduct.Id);

        var productService = productServiceMock.Object;

        Assert.Equal(testProduct.Id, await productService.UpdateAsync(new UpdateProductModel { Id = id.ToString(), Name = "Test uodated" }, default));
    }

    [Fact]
    public async Task ProductService_DeleteAsync_ShouldReturnFalse_WhenProductDoesNotExists()
    {
        var productServiceMock = new Mock<IProductsService>();

        productServiceMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>(), default))
            .ReturnsAsync(() => false);

        var productService = productServiceMock.Object;

        Assert.False(await productService.DeleteAsync(Guid.NewGuid(), default));
    }
}
