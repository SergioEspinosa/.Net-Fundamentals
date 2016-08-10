using System;

namespace CodeSmells.Inmobilidad
{
    //Inmobilidad
    //Esta clase esta acoplada a un contexto web, no puede ser reutilizada
    public class OrderProcessor
    {
        dynamic HttpClient;
        dynamic FileSystem;

        public void Execute(int customerId)
        {
            if (!HttpClient.Session.Active)
            {
                throw new Exception("Inactive session");
            }

            var count = HttpClient.Context.Cache.Get("customerId:" + customerId);
            HttpClient.Context.Cache.Set("customerId:" + customerId, count++);
            dynamic repoCustomer = default(object);
            var customer = repoCustomer.GetById(customerId);
            var notification = new CustomerNotification();
            //Code
            notification.Send(customer);

            FileSystem.WriteToFile(@"C:\folder\log.txt", HttpClient.Session.User.FullInformation());
        }
    }

    public class CustomerNotification
    {
        public void Send(Customer customer)
        {
            //code
        }
    }

    public class Customer  {}
}
