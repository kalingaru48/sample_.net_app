using GearsMonoRepoSample.Manfucaturing.Web.Api.Brokers.Storages;
using GearsMonoRepoSample.Manfucaturing.Web.Api.Models.Products;
using GearsMonoRepoSample.Manfucaturing.Web.Api.Services.Foundations.Products;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace GearsMonoRepoSample.Manufacturing.Tests.Unit.Services.Foundations.Products
{
    public partial class ProductServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IProductService productService;

        public ProductServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.productService = new ProductService(
                storageBroker: this.storageBrokerMock.Object);

        }

        private static Product CreateRandomProduct() =>
            CreateProductFiller().Create();

        private static int GetRandomNumber() => new IntRange(min: 2, max: 10).GetValue();

        private static IQueryable<Product> CreateRandomProducts() =>
            CreateProductFiller().Create(GetRandomNumber()).AsQueryable();


        private static Filler<Product> CreateProductFiller()
        {
            var filler = new Filler<Product>();
            Guid expenseId = Guid.NewGuid();

            filler.Setup()
                .OnProperty(expense => expense.Id).Use(expenseId);

            return filler;
        }
    }
}
