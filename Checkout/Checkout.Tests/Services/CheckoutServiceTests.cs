using Checkout.Services;
using Checkout.Services.Interface;

namespace Checkout.Tests.Services
{
    public class CheckoutServiceTests
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutServiceTests()
        {
            _checkoutService = new CheckoutService();
        }

        [Fact]
        public void Scan_Should_Add_Item()
        {
            Assert.Equal(0, _checkoutService.GetQuantityByItem("A"));

            _checkoutService.Scan("A");

            Assert.Equal(1, _checkoutService.GetQuantityByItem("A"));
        }
    }
}
