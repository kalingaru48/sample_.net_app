using GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products;
using System;
using System.Linq;

namespace GearsMonoRepoSample.Manfucaturing.Web.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Product InsertProduct(Product product);
        IQueryable<Product> SelectAllProducts();
        Product SelectProductById(Guid productId);
        Product UpdateProduct(Product product);
        Product DeleteProduct(Guid productId);
    }
}
