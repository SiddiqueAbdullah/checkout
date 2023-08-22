using Checkout.Services.Interface;

namespace Checkout.Services
{
    public class CheckoutService : ICheckoutService
    {
        private Dictionary<string, int> Cart = new Dictionary<string, int>();

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
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
    }
}
