namespace OnionDesign.After.Core.Models
{
    public class CheckoutHandlerRequest
    {
        public string Token { get; }
        public int OrderId { get; }
        public string PrayerId { get; }
        public string FinalPaymentAmount { get; }
        public int ShoppingCarId { get; set; }

        public CheckoutHandlerRequest(string token, int orderId, string prayerId, string finalAmount, int shoppingCar)
        {
        }
    }
}
