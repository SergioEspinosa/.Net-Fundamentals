namespace OnionDesign.After.Core.Models
{
    public class CheckoutValidation
    {
        public string PaymentConfirmation { get; }
        public bool IsValid { get; }
        public string Message { get; set; }
    }
}
