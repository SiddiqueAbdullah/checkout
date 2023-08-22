namespace Checkout.Models
{
    public class SpecialPrice
    {
        public int RequiredQuantity { get; set; }
        public int Price { get; set; }

        public SpecialPrice(int requiredQuantity, int price)
        {
            RequiredQuantity = requiredQuantity;
            Price = price;
        }
    }
}
