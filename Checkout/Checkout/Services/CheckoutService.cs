using Checkout.Services.Interface;
using Checkout.Data;
using Checkout.Errors;

namespace Checkout.Services
{
    public class CheckoutService : ICheckoutService
    {
        private Dictionary<string, int> Cart = new Dictionary<string, int>();

        public void Scan(string item)
        {
            if(!Database.Products.Any(p => p.SKU == item))
            {
                throw new ItemNotFoundException(item);
            }

            if (Cart.ContainsKey(item))
            {
                ++Cart[item];
            }
            else
            {
                Cart.Add(item, 1);
            }
        }

        public int GetQuantityByItem(string item)
        {
            return Cart.ContainsKey(item) ? Cart[item] : 0;
        }

        public int GetTotalPrice()
        {
            var totalPrice = 0;

            foreach(var item in Cart)
            {
                totalPrice += Database.Products.First(p => p.SKU == item.Key).UnitPrice * item.Value;
            }

            return totalPrice;
        }
    }
}
