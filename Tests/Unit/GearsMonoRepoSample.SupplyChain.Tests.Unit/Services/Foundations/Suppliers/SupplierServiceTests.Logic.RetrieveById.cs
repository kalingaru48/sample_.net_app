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
        public void ShouldGetSupplierById()
        {
            // given
            Supplier randomSupplier = CreateRandomSupplier();
            Supplier storageSupplier = randomSupplier;
            Supplier expectedSupplier = storageSupplier;

            Guid inputSupplierId = randomSupplier.Id;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectSupplierById(inputSupplierId))
                .Returns(storageSupplier);

            // when 
            Supplier actualSupplier = 
                this.supplierService.RetrieveSupplierById(inputSupplierId);

            // then
            actualSupplier.Should().BeEquivalentTo(expectedSupplier);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectSupplierById(inputSupplierId),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
