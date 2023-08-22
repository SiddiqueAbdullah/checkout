namespace Checkout.Models
{
    public class Product
    {
        public string SKU { get; set; }
        public int UnitPrice { get; set; }

        public Product(string sKU, int unitPrice)
        {
            SKU = sKU;
            UnitPrice = unitPrice;
        }
    }
}
