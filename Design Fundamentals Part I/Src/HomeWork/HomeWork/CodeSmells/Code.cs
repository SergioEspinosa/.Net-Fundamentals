using System.Net.Mail;

namespace HomeWork.CodeSmells
{
    public class Client
    {
        public void Execute()
        {
            var agente = new Agente();
            agente.Add(new Person());
        }
    }

    public interface IAgente { void Add(Person person); }
    public class Agente : IAgente
    {
        public void Add(Person person) { new Service().Add(person); }
    }
    public interface IService { void Add(Person person); }
    public class Service : IService
    {
        public void Add(Person person) { new Logic().Add(person); }
    }

    public interface ILogic { void Add(Person person); }
    public class Logic : ILogic
    {
        public void Add(Person person) { new NotificationLogin().Send(person); }
    }

    public interface INotification { void Send(Person person); }
    public class NotificationLogin : INotification
    {
        public void Send(Person person) {
            MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.google.com";
            mail.Subject = "NotificationLogin";
            mail.Body = "this is my test email body";
            client.Send(mail);
        }
    }
    public class NotificationCheckin : INotification
    {
        public void Send(Person person) {
            MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.google.com";
            mail.Subject = "NotificationCheckin";
            mail.Body = "this is my test email body";
            client.Send(mail);
        }
    }
    public class NotificationCheckout : INotification
    {
        public void Send(Person person)
        {
            MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.google.com";
            mail.Subject = "NotificationCheckout";
            mail.Body = "this is my test email body";
            client.Send(mail);
        }
    }

    public class Person { }
}
