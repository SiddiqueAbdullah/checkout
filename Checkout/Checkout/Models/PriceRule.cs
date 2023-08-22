using Checkout.Models.Interfaces;

namespace Checkout.Models
{
    internal class PriceRule : IPriceRule
    {
        public int RequiredQuantity { get; set; }
        public int Price { get; set; }

        public PriceRule(int requiredQuantity, int price)
        {
            RequiredQuantity = requiredQuantity;
            Price = price;
        }
    }
}
