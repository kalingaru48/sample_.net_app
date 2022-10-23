using FluentAssertions;
using GearsMonoRepoSample.SupplyChain.Web.Api.Models.Suppliers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GearsMonoRepoSample.SupplyChain.Tests.Unit.Services.Foundations.Suppliers
{
    public partial class SupplierServiceTests
    {
        [Fact]
        public void ShouldGetAllSuppliers()
        {
            // given
            IQueryable<Supplier> randomSuppliers = CreateRandomSuppliers();
            IQueryable<Supplier> storageSuppliers = randomSuppliers;
            IQueryable<Supplier> expectedSuppliers = storageSuppliers;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllSuppliers())
                .Returns(storageSuppliers);

            // when 
            IQueryable<Supplier> actualSuppliers =
                this.supplierService.RetrieveAllSuppliers();

            // then
            actualSuppliers.Should().BeEquivalentTo(expectedSuppliers);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllSuppliers(),
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();


        }
    }
}
