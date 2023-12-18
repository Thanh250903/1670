namespace BookShoppingCartMvcUI.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int bookId, int qty);
        Task<int> RemoveItem(int bookId);
        Task<Cart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<Cart> GetCart(string userId);
        Task<bool> DoCheckout();
    }
}
