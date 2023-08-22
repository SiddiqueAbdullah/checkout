using Checkout.Services.Interface;
using Checkout.Errors;
using Checkout.Repositories.Interfaces;

namespace Checkout.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly Dictionary<string, int> _cart = new Dictionary<string, int>();
        private readonly IProductRepository _productRepository;

        public CheckoutService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Scan(string item)
        {
            if(_productRepository.FindBySKU(item) == null)
            {
                throw new ItemNotFoundException(item);
            }

            if (_cart.ContainsKey(item))
            {
                ++_cart[item];
            }
            else
            {
                _cart.Add(item, 1);
            }
        }

        public int GetQuantityByItem(string item)
        {
            return _cart.ContainsKey(item) ? _cart[item] : 0;
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;

            foreach(var item in _cart)
            {
                var product = _productRepository.FindBySKU(item.Key);
                totalPrice += product.GetPriceByQuantity(item.Value);
            }

            return totalPrice;
        }
    }
}
