using GearsMonoRepoSample.SupplyChain.Web.Api.Models.Suppliers;
using System;
using System.Collections.Generic;

namespace GearsMonoRepoSample.SupplyChain.Web.Api.Brokers.StorageBrokers
{
    public partial class StorageBroker : IStorageBroker
    {
        private readonly List<Supplier> suppliers;

        public StorageBroker()
        {
            this.suppliers = SupplierData();
        }


        private List<Supplier> SupplierData()
        {
            List<Supplier> suppliers = new List<Supplier>
            {
                new Supplier
                {
                    Id = new Guid("84f29abd-ea64-4195-9b87-c56edcd6a7b5"),
                    Name = "Supplier 1"
                },
                new Supplier
                {
                    Id = new Guid("3c104ea3-7d12-4da1-9071-fb8c6998ca34"),
                    Name = "Supplier 2"
                },
                new Supplier
                {
                    Id = new Guid("df89a7b7-adaf-4957-9a7c-db38d7487e35"),
                    Name = "Supplier 3"
                }
            };



            return suppliers;
        }
    }
}
