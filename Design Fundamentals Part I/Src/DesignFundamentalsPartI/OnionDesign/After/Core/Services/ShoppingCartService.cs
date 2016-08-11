using OnionDesign.After.Core.Contracts;

namespace OnionDesign.After.Core.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository repository;

        public ShoppingCartService(IShoppingCartRepository repository)
        {
            this.repository = repository;
        }

        public void EmptyCart(int id)
        {
            var cartItems = repository.GetItems(id);
            foreach (var cartItem in cartItems)
            {
                repository.Remove(cartItem);
            }
        }
    }
}
