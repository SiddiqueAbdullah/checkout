namespace Checkout.Services.Interface
{
    public interface ICheckoutService
    {
        void Scan(string item);
        int GetQuantityByItem(string item);
        int GetTotalPrice();
    }
}
