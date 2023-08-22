using Checkout.Models;

namespace Checkout.Data
{
    public static class Database
    {
        public static List<Product> Products { get; }
        public static List<SpecialPrice> SpecialPrices { get; }

        static Database()
        {
            Products = new List<Product>
            {
                new("A", 50),
                new("B", 30),
                new("C", 20),
                new("D", 15)
            };

            SpecialPrices = new List<SpecialPrice>
            {
                new(3, 130),
                new(2, 45)
            };
        }
    }
}
