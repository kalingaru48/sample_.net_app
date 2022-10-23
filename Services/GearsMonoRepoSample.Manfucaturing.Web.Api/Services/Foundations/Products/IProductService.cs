using GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products;
using System;
using System.Linq;

namespace GearsMonoRepoSample.Manfucaturing.Web.Api.Services.Foundations.Products
{
    public partial interface IProductService
    {
        Product AddProduct(Product product);
        IQueryable<Product> RetrieveAllProducts();
        Product RetrieveProductById(Guid productId);
        Product ModifyProduct(Product product);
        Product RemoveProduct(Guid productId);
    }
}
