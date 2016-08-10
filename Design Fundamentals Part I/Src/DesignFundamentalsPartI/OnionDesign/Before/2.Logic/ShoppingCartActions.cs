using System;
using System.Web;
using OnionDesign.Before._3.Data;

namespace OnionDesign.Before._2.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EmptyCart()
        {
            var _db = new ShoppingCartRepository();
            string shoppingCartId = GetCartId();
            var cartItems = _db.GetItems(shoppingCartId);
            foreach (var cartItem in cartItems)
            {
                _db.Remove(cartItem);
            }
        }
        private const string CartSessionKey = "CartSessionKey";

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }
    }
}
