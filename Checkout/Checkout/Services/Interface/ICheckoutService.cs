namespace Checkout.Services.Interface
{
    public interface ICheckoutService
    {
        void Scan(string item);
        int GetTotalPrice();
        int GetQuantityByItem(string item);
    }
}
