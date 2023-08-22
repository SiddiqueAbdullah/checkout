using Checkout.Models.Interfaces;

namespace Checkout.Models
{
    public class Product : IProduct
    {
        public string SKU { get; set; }
        public IEnumerable<IPriceRule> PriceRules { get; set; }

        public Product(string sKU)
        {
            SKU = sKU;
            PriceRules = new List<PriceRule>();
        }

        public int GetPriceByQuantity(int quantity)
        {
            var unitPrice = PriceRules.First(pr => pr.RequiredQuantity == 1).Price;
            var qualifiedPriceRule = PriceRules.FirstOrDefault(pr => pr.RequiredQuantity > 1 && pr.RequiredQuantity <= quantity);

            if(qualifiedPriceRule == null)
            {
                return unitPrice * quantity;
            }

            return (quantity / qualifiedPriceRule.RequiredQuantity) * qualifiedPriceRule.Price + (quantity % qualifiedPriceRule.RequiredQuantity) * unitPrice;
        }

        public IProduct AddPriceRule(int requiredQuantity, int price)
        {
            ((List<PriceRule>)PriceRules).Add(new PriceRule(requiredQuantity, price));

            return this;
        }
    }

    
}
