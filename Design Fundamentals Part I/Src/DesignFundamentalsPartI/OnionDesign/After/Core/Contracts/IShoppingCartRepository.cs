using System.Collections.Generic;

namespace OnionDesign.After.Core.Contracts
{
    public interface IShoppingCartRepository
    {
        List<int> GetItems(int id);
        void Remove(int id);
    }
}
