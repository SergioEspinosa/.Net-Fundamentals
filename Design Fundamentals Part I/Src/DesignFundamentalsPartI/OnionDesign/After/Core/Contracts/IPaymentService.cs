using OnionDesign.After.Core.Models;

namespace OnionDesign.After.Core.Contracts
{
    public interface IPaymentService
    {
        CheckoutValidation Checkout(CheckoutHandlerRequest request);
    }
}
