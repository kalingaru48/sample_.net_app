using GearsMonoRepoSample.SupplyChain.Web.Api.Models.Suppliers;
using System;
using System.Linq;

namespace GearsMonoRepoSample.SupplyChain.Web.Api.Brokers.StorageBrokers
{
    public partial interface IStorageBroker
    {
        Supplier InsertSupplier(Supplier supplier);
        IQueryable<Supplier> SelectAllSuppliers();
        Supplier SelectSupplierById(Guid supplierId);
        Supplier UpdateSupplier(Supplier supplier);
        Supplier DeleteSupplier(Guid supplierId);
     
    }
}
