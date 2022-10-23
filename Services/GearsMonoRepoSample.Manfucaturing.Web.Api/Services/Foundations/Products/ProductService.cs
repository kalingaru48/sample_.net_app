using GearsMonoRepoSample.Manfucaturing.Web.Api.Brokers.Storages;
using GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products;
using System;
using System.Linq;

namespace GearsMonoRepoSample.Manfucaturing.Web.Api.Services.Foundations.Products
{
    public partial class ProductService : IProductService
    {
        private readonly IStorageBroker storageBroker;

        public ProductService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public Product AddProduct(Product product)
        {
            return this.storageBroker.InsertProduct(product);
        }

        public Product ModifyProduct(Product product)
        {
            return this.storageBroker.UpdateProduct(product);
        }

        public Product RemoveProduct(Guid productId)
        {
            return this.storageBroker.DeleteProduct(productId);
        }

        public IQueryable<Product> RetrieveAllProducts()
        {
            return this.storageBroker.SelectAllProducts();
        }

        public Product RetrieveProductById(Guid productId)
        {
            return this.storageBroker.SelectProductById(productId);
        }
    }
}
