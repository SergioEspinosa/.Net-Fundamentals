using System.Net.Mail;

namespace CodeSmells.RepeticionInnecesaria
{
    public class Customer { }
    public class OrderProcessor
    {

        public void Execute(int customerId)
        {
            dynamic repoCustomer = default(object);
            var customer = repoCustomer.GetById(customerId);
            //Code
            Send(customer);
        }

        private void Send(Customer customer)
        {
            MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.google.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            client.Send(mail);
        }
    }

    public class DeliveryProcessor
    {

        public void Execute(int productId, int orderId, int customerId)
        {
            dynamic repoDelivery = default(object);
            var product = repoDelivery.GetById(productId);
            dynamic repoOrder = default(object);
            var order = repoOrder.GetById(orderId);
            dynamic repoCustomer = default(object);
            var customer = repoCustomer.GetById(customerId);
            //Code
            Send(customer);
        }

        private void Send(Customer customer)
        {
            MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.google.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            client.Send(mail);
        }
    }

    public class CheckOutProcessor
    {

        public void Execute(int productId, int orderId, int customerId)
        {
            dynamic repoOrder = default(object);
            var order = repoOrder.GetById(orderId);
            dynamic repoCustomer = default(object);
            var customer = repoCustomer.GetById(customerId);
            //Code
            Send(customer);
        }

        private void Send(Customer customer)
        {
            MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.google.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            client.Send(mail);
        }
    }
}
