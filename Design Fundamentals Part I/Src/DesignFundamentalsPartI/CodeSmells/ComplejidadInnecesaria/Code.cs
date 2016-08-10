namespace CodeSmells.ComplejidadInnecesaria
{
    public class Person { }
    
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
        public void Add(Person person) { new Repo().Add(person); }
    }

    public interface IRepo { void Add(Person person); }
    public class Repo : IRepo
    {
        public void Add(Person person) { }
    }
}
