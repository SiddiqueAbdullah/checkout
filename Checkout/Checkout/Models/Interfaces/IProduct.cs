namespace Checkout.Models.Interfaces
{
    public interface IProduct
    {
        public string SKU { get; set; }
        public IEnumerable<IPriceRule> PriceRules { get; set; }

        int GetPriceByQuantity(int quantity);
        IProduct AddPriceRule(int requiredQuantity, int price);
    }
}
