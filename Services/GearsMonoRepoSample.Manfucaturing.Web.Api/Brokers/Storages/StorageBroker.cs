using GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products;
using System;
using System.Collections.Generic;

namespace GearsMonoRepoSample.Manfucaturing.Web.Api.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        private readonly List<Product> products;

        public StorageBroker()
        {
            this.products = ProductsData();
        }


        private List<Product> ProductsData()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = new Guid("9355dda7-d391-49a2-9e20-5c4e51f6f34a"),
                    Name = "Car Window",
                    Price = 20000.00m
                },
                new Product
                {
                    Id = new Guid("aac8fe29-d0b0-4183-9c5b-d161a399700a"),
                    Name = "Break Pads",
                    Price = 15000.00m
                },
                new Product
                {
                    Id = new Guid("c865ebd9-f974-4444-b078-a683639d3f92"),
                    Name = "Break Light",
                    Price = 1000.00m
                },
                new Product
                {
                    Id = new Guid("84392714-21ae-4727-ae85-4c64fb144e03"),
                    Name = "Alloy Wheel Set",
                    Price = 120000.00m
                },
                new Product
                {
                    Id = new Guid("921005b3-b5a7-44cc-8c3f-a07aad822233"),
                    Name = "Wiper Set",
                    Price = 5000.00m
                }
            };



            return products;
        }
    }
}
