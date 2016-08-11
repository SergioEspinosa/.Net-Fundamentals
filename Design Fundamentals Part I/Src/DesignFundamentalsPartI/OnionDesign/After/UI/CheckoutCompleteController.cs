using System;
using OnionDesign.After.Core.Contracts;
using OnionDesign.After.Core.Exceptions;
using OnionDesign.After.Core.Handlers;
using OnionDesign.After.Core.Models;
using OnionDesign.After.Core.Services;
using OnionDesign.After.Infraestructure.Repositories;

namespace OnionDesign.After._1.UI
{
    public class CheckoutCompleteController : ApiController
    {
        private readonly ICheckoutHandler handler;
        public CheckoutCompleteController()
        {
            handler =
                new CheckoutHandler(
                    new OrderRepository(), 
                    new PaypalPaymentService(), 
                    new ShoppingCartService(new ShoppingCartRepository()));
        }

        public string Post()
        {
            
            if ((string)Session("userCheckoutCompleted") != "true")
            {
                System.Web.HttpContext.Current.Response.Redirect("CheckoutError.aspx?" + "Desc=Unvalidated%20Checkout.");
                return null;
            }
            
            var request =
                new CheckoutHandlerRequest(
                    Session("token").ToString(), 
                    Convert.ToInt32(Session("currentOrderID")),
                    Session("payerId").ToString(),
                    Session("payment_amt").ToString(), 
                    Convert.ToInt32(Session("CarId")));

            try
            {
                var response = handler.Handle(request);

                return OK(response.PaymentConfirmation);
            }
            catch (CheckoutException ex)
            {
                System.Web.HttpContext.Current.Response.Redirect("CheckoutError.aspx?" + "Desc=Unvalidated%20Checkout.");
                return Error(ex.Message);
            }
        }

        private static object Session(string key)
            => System.Web.HttpContext.Current.Session[key];

        private string OK(string paymentConfirmation) => null; 

        private string Error(string message) => null;
    }
}
