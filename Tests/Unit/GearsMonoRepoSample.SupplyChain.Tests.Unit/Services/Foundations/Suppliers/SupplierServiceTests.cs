using GearsMonoRepoSample.SupplyChain.Web.Api.Brokers.StorageBrokers;
using GearsMonoRepoSample.SupplyChain.Web.Api.Models.Suppliers;
using GearsMonoRepoSample.SupplyChain.Web.Api.Services.Foundations.Suppliers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace GearsMonoRepoSample.SupplyChain.Tests.Unit.Services.Foundations.Suppliers
{
    public partial class SupplierServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly ISupplierService supplierService;

        public SupplierServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.supplierService = new SupplierService(
                storageBroker: this.storageBrokerMock.Object);
        }

        private static Supplier CreateRandomSupplier() =>
            CreateSupplierFiller().Create();

        private static int GetRandomNumber() => new IntRange(min: 2, max: 10).GetValue();

        private static IQueryable<Supplier> CreateRandomSuppliers() =>
            CreateSupplierFiller().Create(GetRandomNumber()).AsQueryable();


        private static Filler<Supplier> CreateSupplierFiller()
        {
            var filler = new Filler<Supplier>();
            Guid supplierId = Guid.NewGuid();

            filler.Setup()
                .OnProperty(expense => expense.Id).Use(supplierId);

            return filler;
        }
    }
}
