using OnionDesign.After.Core.Models;

namespace OnionDesign.After.Core.Contracts
{
    public interface IOrderRepository
    {
        Order GetById(int idOrder);
        void UpdateTransactionCode(Order order);
    }
}
