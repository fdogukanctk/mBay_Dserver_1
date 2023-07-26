using mBay_Client.ViewModels;

namespace mBay_Client.Service.IService
{
    public interface ICartService
    {
        public event Action OnChange;
        Task DecrementItem(ShoppingCart shoppingCart);
        Task IncrementItem(ShoppingCart shoppingCart);
    }
}
