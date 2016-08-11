using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Add(Person person) { new NotificationLogin().Add(person); }
    }

    public interface INotification { void Add(Person person); }
    public class NotificationLogin : INotification
    {
        public void Add(Person person) { }
    }

    public class Person { }
}
