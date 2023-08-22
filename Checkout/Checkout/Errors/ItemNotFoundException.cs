namespace Checkout.Errors
{
    public class ItemNotFoundException : Exception
    {
        public string Item { get; private set; }

        public ItemNotFoundException(string item) : base($"Item {item} not found")
        {
            Item = item;
        }
    }
}
