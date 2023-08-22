namespace Checkout.Models.Interfaces
{
    public interface IPriceRule
    {
        public int RequiredQuantity { get; set; }
        public int Price { get; set; }
    }
}
