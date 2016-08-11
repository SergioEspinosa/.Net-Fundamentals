using System;
using OnionDesign.After.Core.Contracts;
using OnionDesign.After.Core.Exceptions;
using OnionDesign.After.Core.Models;

namespace OnionDesign.After.Core.Handlers
{
    public class CheckoutHandler : ICheckoutHandler
    {
        private readonly IOrderRepository repository;
        private readonly IPaymentService paymentService;
        private readonly IShoppingCartService shoppingCartService;
        public CheckoutHandler(IOrderRepository repository, IPaymentService paymentService, IShoppingCartService shoppingCartService)
        {
            this.repository = repository;
            this.paymentService = paymentService;
            this.shoppingCartService = shoppingCartService;
        }

        public CheckoutHandlerResponse Handle(CheckoutHandlerRequest request)
        {
            if (request.OrderId <= 0) throw new ArgumentException(nameof(request.OrderId));

            var checkoutValidation = paymentService.Checkout(request);
            if (!checkoutValidation.IsValid)
            {
                throw new CheckoutException(checkoutValidation.Message);
            }

            Order order = repository.GetById(request.OrderId);
            // Update the order to reflect payment has been completed.
            order.PaymentTransactionId = checkoutValidation.PaymentConfirmation;
            // Save to DB.
            repository.UpdateTransactionCode(order);
            shoppingCartService.EmptyCart(request.ShoppingCarId);

            return new CheckoutHandlerResponse();
        }
    }
}
