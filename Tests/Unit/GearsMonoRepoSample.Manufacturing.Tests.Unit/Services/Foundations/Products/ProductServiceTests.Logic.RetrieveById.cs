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
        public void ShouldRetrieveProductById()
        {
            // given
            Product randomProduct = CreateRandomProduct();
            Guid inputProductId = randomProduct.Id;

            Product storageProduct = randomProduct;
            Product expectedProduct = storageProduct;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectProductById(inputProductId))
                .Returns(storageProduct);

            // when 
            Product actualProduct =
                this.productService.RetrieveProductById(inputProductId);

            // then 
            actualProduct.Should().BeEquivalentTo(expectedProduct);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectProductById(inputProductId)
                , Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }

    }
}
