using FluentAssertions;
using Force.DeepCloner;
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
        public void ShouldModifySupplier()
        {
            // given
            Supplier randomSupplier = CreateRandomSupplier();

            Supplier inputSupplier = randomSupplier;
            Supplier afterUpdateSupplier = inputSupplier;
            Supplier expectedSupplier = afterUpdateSupplier;
            Supplier beforeUpdateStorageSupplier = randomSupplier.DeepClone();

            Guid SupplierId = randomSupplier.Id;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectSupplierById(SupplierId))
                .Returns(beforeUpdateStorageSupplier);

            this.storageBrokerMock.Setup(broker =>
                broker.UpdateSupplier(inputSupplier))
                .Returns(afterUpdateSupplier);

            // when
            Supplier actualSupplier =
                this.supplierService.ModifySupplier(inputSupplier);

            // then 
            actualSupplier.Should().BeEquivalentTo(expectedSupplier);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdateSupplier(inputSupplier),
                Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
