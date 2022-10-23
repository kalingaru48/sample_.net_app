using FluentAssertions;
using GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products;
using Moq;
using Xunit;

namespace GearsMonoRepoSample.Manufacturing.Tests.Unit.Services.Foundations.Products
{
    public partial class ProductServiceTests
    {
        [Fact]
        public void ShouldAddProduct()
        {
            // given 
            Product randomProduct = CreateRandomProduct();

            Product inputProduct = randomProduct;
            Product storageProduct = inputProduct;
            Product expectedProduct = storageProduct;

            this.storageBrokerMock.Setup(broker =>
                broker.InsertProduct(inputProduct))
                .Returns(storageProduct);

            // when
            Product actualProduct = 
                this.productService.AddProduct(inputProduct);

            // then
            actualProduct.Should().BeEquivalentTo(expectedProduct);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertProduct(randomProduct),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
