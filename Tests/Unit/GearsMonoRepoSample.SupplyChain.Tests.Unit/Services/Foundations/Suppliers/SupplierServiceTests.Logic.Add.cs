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
        public void ShouldAddSupplier()
        {
            // given
            Supplier randomSupplier = CreateRandomSupplier();
            Supplier inputSupplier = randomSupplier;
            Supplier storageSupplier = inputSupplier;
            Supplier expectedSupplier = storageSupplier;


            this.storageBrokerMock.Setup(broker =>
                broker.InsertSupplier(inputSupplier))
                .Returns(storageSupplier);

            // when 
            Supplier actualSupplier =
                this.supplierService.AddSupplier(inputSupplier);

            // then
            actualSupplier.Should().BeEquivalentTo(expectedSupplier);

            this.storageBrokerMock.Verify(broker => 
                broker.InsertSupplier(inputSupplier), 
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
