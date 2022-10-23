using GearsMonoRepoSample.SupplyChain.Web.Api.Brokers.StorageBrokers;
using GearsMonoRepoSample.SupplyChain.Web.Api.Models.Suppliers;
using System;
using System.Linq;

namespace GearsMonoRepoSample.SupplyChain.Web.Api.Services.Foundations.Suppliers
{
    public partial class SupplierService : ISupplierService
    {

        private readonly IStorageBroker storageBroker;

        public SupplierService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public Supplier AddSupplier(Supplier supplier)
        {
            return this.storageBroker.InsertSupplier(supplier);
        }

        public Supplier ModifySupplier(Supplier supplier)
        {
            return storageBroker.UpdateSupplier(supplier);
        }

        public Supplier RemoveSupplier(Guid supplierId)
        {
            return this.storageBroker.DeleteSupplier(supplierId);
        }

        public IQueryable<Supplier> RetrieveAllSuppliers()
        {
            return this.storageBroker.SelectAllSuppliers();
        }

        public Supplier RetrieveSupplierById(Guid supplierId)
        {
            return this.storageBroker.SelectSupplierById(supplierId);
        }
    }
}
