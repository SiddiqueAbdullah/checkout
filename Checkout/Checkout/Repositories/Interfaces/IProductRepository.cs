using Checkout.Models.Interfaces;

namespace Checkout.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public IProduct FindBySKU(string sKU);
    }
}
