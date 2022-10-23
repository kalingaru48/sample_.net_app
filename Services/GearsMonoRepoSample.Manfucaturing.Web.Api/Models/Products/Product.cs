using System;

namespace GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
