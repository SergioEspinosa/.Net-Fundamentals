using OnionDesign.After.Core.Models;

namespace OnionDesign.After.Core.Contracts
{
    public interface ICheckoutHandler
    {
        CheckoutHandlerResponse Handle(CheckoutHandlerRequest request);
    }
}
