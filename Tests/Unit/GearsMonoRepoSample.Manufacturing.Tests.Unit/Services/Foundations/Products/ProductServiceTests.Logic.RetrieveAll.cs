using FluentAssertions;
using GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products;
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
        public void ShouldRetrieveAllProducts()
        {
            // given
            IQueryable<Product> randomProducts = CreateRandomProducts();
            IQueryable<Product> storageProducts = randomProducts;
            IQueryable<Product> expectedProducts = storageProducts;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllProducts())
                .Returns(storageProducts);

            // when
            IQueryable<Product> actualProducts = 
                this.productService.RetrieveAllProducts();


            // then 
            actualProducts.Should().BeEquivalentTo(expectedProducts);

            this.storageBrokerMock.Verify(broker => broker.SelectAllProducts());    

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
