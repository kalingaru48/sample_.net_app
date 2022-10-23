using FluentAssertions;
using Force.DeepCloner;
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
        public void ShouldModifyProduct()
        {
            // given
            Product randomProduct = CreateRandomProduct();

            Product inputProduct = randomProduct;
            Product afterUpdateProduct = inputProduct;
            Product expectedProduct = afterUpdateProduct;
            Product beforeUpdateStorageProduct = randomProduct.DeepClone();

            Guid productId = randomProduct.Id;

            this.storageBrokerMock.Setup(broker => 
                broker.SelectProductById(productId))
                .Returns(beforeUpdateStorageProduct);

            this.storageBrokerMock.Setup(broker => 
                broker.UpdateProduct(inputProduct))
                .Returns(afterUpdateProduct);

            // when
            Product actualProduct =
                this.productService.ModifyProduct(inputProduct);

            // then 
            actualProduct.Should().BeEquivalentTo(expectedProduct);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateProduct(inputProduct),
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();

        }
    }
}
