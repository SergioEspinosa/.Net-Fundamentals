namespace CodeSmells.Fragilidad
{
    //Fragilidad
    //Agregando un nuevo parametro a la funcion Send
    //Agregando una nueva propiedad a la clase Customer y usarlo en el metodo Send
    public class OrderProcessor
    {

        public void Execute(int customerId)
        {
            dynamic repoCustomer = default(object);
            var customer = repoCustomer.GetById(customerId);
            var notification = new CustomerNotification();
            //Code
            notification.Send(customer);
        }
    }

    public class PaymentProcessor
    {

        public void Execute(int customerId)
        {
            dynamic repoCustomer = default(object);
            var customer = repoCustomer.GetById(customerId);
            var notification = new CustomerNotification();
            //Code
            notification.Send(customer);
        }
    }

    public class CustomerNotification
    {
        public void Send(Customer customer)
        {
        }
    }

    public class Customer { }

}
