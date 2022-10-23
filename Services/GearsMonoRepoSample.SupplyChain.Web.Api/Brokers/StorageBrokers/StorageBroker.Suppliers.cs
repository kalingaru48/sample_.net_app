using GearsMonoRepoSample.SupplyChain.Web.Api.Models.Suppliers;
using System;
using System.Linq;

namespace GearsMonoRepoSample.SupplyChain.Web.Api.Brokers.StorageBrokers
{
    public partial class StorageBroker : IStorageBroker
    {
        public Supplier InsertSupplier(Supplier supplier)
        {
            this.suppliers.Add(supplier);

            return supplier;
        }

        public IQueryable<Supplier> SelectAllSuppliers()
        {
            return this.suppliers.AsQueryable();
        }

        public Supplier SelectSupplierById(Guid supplierId)
        {
            return this.suppliers.Find(supplier => supplier.Id == supplierId);
        }

        public Supplier UpdateSupplier(Supplier supplier)
        {
            this.DeleteSupplier(supplier.Id);
            this.InsertSupplier(supplier);

            return supplier;
        }
        public Supplier DeleteSupplier(Guid supplierId)
        {
            var supplier = this.SelectSupplierById(supplierId);
            this.suppliers.Remove(supplier);

            return supplier;
        }
    }
}
