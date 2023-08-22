namespace Checkout.Errors
{
    public class PriceRulesNotSetException : Exception
    {
        public string SKU { get; private set; }

        public PriceRulesNotSetException(string sku) : base($"Price rules not set for SKU {sku}")
        {
            SKU = sku;
        }
    }
}
