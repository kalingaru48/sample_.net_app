using GearsMonoRepoSample.SupplyChain.Web.Api.Models.Suppliers;
using System;
using System.Linq;

namespace GearsMonoRepoSample.SupplyChain.Web.Api.Services.Foundations.Suppliers
{
    public partial interface ISupplierService
    {
        Supplier AddSupplier(Supplier supplier);
        IQueryable<Supplier> RetrieveAllSuppliers();
        Supplier RetrieveSupplierById(Guid supplierId);
        Supplier ModifySupplier(Supplier supplier);
        Supplier RemoveSupplier(Guid supplierId);
    }
}
