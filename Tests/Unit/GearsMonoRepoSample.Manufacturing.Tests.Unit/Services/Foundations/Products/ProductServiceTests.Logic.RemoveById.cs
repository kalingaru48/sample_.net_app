using FluentAssertions;
using GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GearsMonoRepoSample.Manufacturing.Tests.Unit.Services.Foundations.Products
{
    public partial class ProductServiceTests
    {
        [Fact]
        public void ShouldRemoveProductById()
        {
            // given
            Product randomProduct = CreateRandomProduct();
            Guid inputProductId = randomProduct.Id;
            Product storageProduct = randomProduct;
            Product expectedProduct = storageProduct;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectProductById(inputProductId))
                .Returns(storageProduct);

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteProduct(storageProduct.Id))
                .Returns(expectedProduct);

            // when
            Product actualProduct = 
                this.productService.RemoveProduct(inputProductId);

            // then
            actualProduct.Should().BeEquivalentTo(expectedProduct);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteProduct(inputProductId),
                Times.Once);


            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
