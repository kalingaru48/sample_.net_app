using GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products;
using System;
using System.Linq;

namespace GearsMonoRepoSample.Manfucaturing.Web.Api.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        public Product InsertProduct(Product product)
        {
            this.products.Add(product);
            return product;
        }
        public IQueryable<Product> SelectAllProducts()
        {
            return this.products.AsQueryable();
        }
        public Product SelectProductById(Guid productId)
        {
            return this.products.Find(product => product.Id == productId);
        }
        public Product UpdateProduct(Product product)
        {
            this.DeleteProduct(product.Id);
            this.InsertProduct(product);

            return product;
        }
        public Product DeleteProduct(Guid productId)
        {
            Product product = this.products.Find(product => product.Id == productId);
            this.products.Remove(product);

            return product;
        }
    }
}
