using Checkout.Services;
using Checkout.Services.Interface;
using Checkout.Errors;
using Checkout.Tests.Mocks;

namespace Checkout.Tests.Services
{
    public class CheckoutServiceTests
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutServiceTests()
        {
            _checkoutService = new CheckoutService(new MockedProductRepository());
        }

        [Fact]
        public void Scan_Should_Add_Item()
        {
            Assert.Equal(0, _checkoutService.GetQuantityByItem("A"));

            _checkoutService.Scan("A");

            Assert.Equal(1, _checkoutService.GetQuantityByItem("A"));
        }

        [Fact]
        public void Scan_Should_Add_Multiple_Items()
        {
            Assert.Equal(0, _checkoutService.GetQuantityByItem("A"));
            Assert.Equal(0, _checkoutService.GetQuantityByItem("B"));

            _checkoutService.Scan("A");
            _checkoutService.Scan("B");

            Assert.Equal(1, _checkoutService.GetQuantityByItem("A"));
            Assert.Equal(1, _checkoutService.GetQuantityByItem("B"));
        }

        [Fact]
        public void Scan_Should_Increase_Quantity_On_Multiple_Scan_Of_Same_Item()
        {
            Assert.Equal(0, _checkoutService.GetQuantityByItem("A"));

            _checkoutService.Scan("A");

            Assert.Equal(1, _checkoutService.GetQuantityByItem("A"));

            _checkoutService.Scan("A");

            Assert.Equal(2, _checkoutService.GetQuantityByItem("A"));
        }

        [Fact]
        public void Scan_Should_Throw_On_Item_Not_Found()
        {
            Assert.Throws<ItemNotFoundException>(() => _checkoutService.Scan("Z"));
        }

        [Fact]
        public void GetTotalPrice_Should_Return_Item_Price()
        {
            _checkoutService.Scan("A");

            var price = _checkoutService.GetTotalPrice();

            Assert.Equal(50, price);
        }

        [Fact]
        public void GetTotalPrice_Should_Return_Multiple_Item_Total_Price()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");

            var price = _checkoutService.GetTotalPrice();

            Assert.Equal(50 * 2 + 30, price);
        }

        [Fact]
        public void GetTotalPrice_Should_Use_Special_Price_If_Available()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");

            var price = _checkoutService.GetTotalPrice();

            Assert.Equal(130, price);
        }

        [Fact]
        public void GetTotalPrice_Should_Use_Special_Price_Only_For_Qualified_Quantity()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");

            var price = _checkoutService.GetTotalPrice();

            Assert.Equal(130 + 50, price);
        }

        [Fact]
        public void GetTotalPrice_Should_Use_Special_Price_On_Unsorted_Items()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");

            var price = _checkoutService.GetTotalPrice();

            Assert.Equal(130 + 30, price);
        }
    }
}
