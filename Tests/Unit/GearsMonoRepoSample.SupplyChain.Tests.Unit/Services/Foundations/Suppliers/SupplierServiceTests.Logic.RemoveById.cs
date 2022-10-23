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
        public void ShouldRemoveSupplierById()
        {
            // given
            Supplier randomSupplier = CreateRandomSupplier();
            Guid inputSupplierId = randomSupplier.Id;
            Supplier storageSupplier = randomSupplier;
            Supplier expectedSupplier = storageSupplier;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectSupplierById(inputSupplierId))
                .Returns(storageSupplier);

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteSupplier(storageSupplier.Id))
                .Returns(expectedSupplier);

            // when
            Supplier actualSupplier =
                this.supplierService.RemoveSupplier(inputSupplierId);

            // then
            actualSupplier.Should().BeEquivalentTo(expectedSupplier);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteSupplier(inputSupplierId),
                Times.Once);


            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
