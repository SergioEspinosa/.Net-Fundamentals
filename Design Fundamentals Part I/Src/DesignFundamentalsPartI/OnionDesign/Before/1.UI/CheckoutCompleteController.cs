using System;
using OnionDesign.Before._2.Logic;
using OnionDesign.Before._3.Data;
using OnionDesign.Before.Model;

namespace OnionDesign.Before._1.UI
{
    public class CheckoutCompleteController : ApiController
    {
        public void Post()
        {
            // Verify user has completed the checkout process.
            if ((string)System.Web.HttpContext.Current.Session["userCheckoutCompleted"] != "true")
            {
               System.Web.HttpContext.Current.Session["userCheckoutCompleted"] = string.Empty;
                System.Web.HttpContext.Current.Response.Redirect("CheckoutError.aspx?" + "Desc=Unvalidated%20Checkout.");
            }

            NVPAPICaller payPalCaller = new NVPAPICaller();

            string retMsg = "";
            string token = "";
            string finalPaymentAmount = "";
            string PayerID = "";
            NVPCodec decoder = new NVPCodec();

            token = System.Web.HttpContext.Current.Session["token"].ToString();
            PayerID = System.Web.HttpContext.Current.Session["payerId"].ToString();
            finalPaymentAmount = System.Web.HttpContext.Current.Session["payment_amt"].ToString();

            bool ret = payPalCaller.DoCheckoutPayment(finalPaymentAmount, token, PayerID, ref decoder, ref retMsg);
            if (ret)
            {
                // Retrieve PayPal confirmation value.
                string PaymentConfirmation = decoder["PAYMENTINFO_0_TRANSACTIONID"].ToString();

                OrderRepository _db = new OrderRepository();
                // Get the current order id.
                int currentOrderId = -1;
                if (System.Web.HttpContext.Current.Session["currentOrderId"] != null)
                {
                    currentOrderId = Convert.ToInt32(System.Web.HttpContext.Current.Session["currentOrderID"]);
                }
                Order order;
                if (currentOrderId >= 0)
                {
                    // Get the order based on order id.
                    order = _db.GetById(currentOrderId);
                    // Update the order to reflect payment has been completed.
                    order.PaymentTransactionId = PaymentConfirmation;
                    // Save to DB.
                    _db.Update(order);
                }

                // Clear shopping cart.
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.EmptyCart();
                }

                // Clear order id.
                System.Web.HttpContext.Current.Session["currentOrderId"] = string.Empty;
            }
            else
            {
                System.Web.HttpContext.Current.Response.Redirect("CheckoutError.aspx?" + retMsg);
            }
        }
    }
}
