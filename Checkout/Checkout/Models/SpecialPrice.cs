namespace Checkout.Models
{
    public class SpecialPrice
    {
        public string Item { get; set; }
        public int RequiredQuantity { get; set; }
        public int Price { get; set; }

        public SpecialPrice(string item, int requiredQuantity, int price)
        {
            Item = item;
            RequiredQuantity = requiredQuantity;
            Price = price;
        }
    }
}
