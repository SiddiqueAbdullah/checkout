using Checkout.Models.Interfaces;
using Checkout.Repositories.Interfaces;
using Checkout.Models;

namespace Checkout.Tests.Mocks
{
    internal class MockedProductRepository : IProductRepository
    {
        public IEnumerable<IProduct> Products { get;  }

        public MockedProductRepository()
        {
            Products = new List<IProduct>
            {
                new Product("A").AddPriceRule(1, 50).AddPriceRule(3, 130),
                new Product("B").AddPriceRule(1, 30).AddPriceRule(2, 45),
                new Product("C").AddPriceRule(1, 20),
                new Product("D").AddPriceRule(1, 15)
            };
        }

        public IProduct? FindBySKU(string sKU)
        {
            return Products.FirstOrDefault(p => p.SKU == sKU);
        }
    }
}
