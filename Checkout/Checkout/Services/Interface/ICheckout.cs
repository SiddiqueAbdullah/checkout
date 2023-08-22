namespace Checkout.Services.Interface
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
