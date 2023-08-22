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
        public void Scan_Should_Run_Success()
        {
            _checkoutService.Scan("A");
        }
    }
}
