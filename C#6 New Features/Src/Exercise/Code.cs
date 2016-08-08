using System;
using System.Collections.Generic;

namespace Exercise
{
    public enum LoggerType
    {
        TextFile,
        Console
    }
    
    public class Person
    {
        public string Name { get; }

        public Person(string name)
        {
            Name = name;
        }
    }
    public class Address
    {
        public string Street { get; }

        public Address(string street)
        {
            Street = street;
        }
    }

    public class Product
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
    public class Order
    {
        public Person Person { get; }
        public Address DeliveryAddress { get; }
        public Address BillingAddress { get; }

        public List<Product> Products { get; } 
        public Order(Person person, Address delivery, Address billing, List<Product> products)
        {
            Person = person;
            DeliveryAddress = delivery ?? billing;
            BillingAddress = billing;
            Products = products;
        }

        public bool QualifiesForDiscount()
        {
            return Person != null && Person.Name != null
                && Person.Name == "Alex";
        }

        public bool IsValid()
        {
            if (BillingAddress != null && BillingAddress.Street != null)
            {
                if (DeliveryAddress != null && DeliveryAddress.Street != null)
                {
                    if (Person != null && Person.Name != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }

    public class OrderProcessor
    {
        public void Execute(Order order)
        {
            NullValidator.Check(order,"order");
            if (order.IsValid() && order.QualifiesForDiscount())
            {
                //Code
                Console.WriteLine("Order processed");
            }
            else
            {
                throw  new Exception("Order not processed");
            }
        }
    }

    public class LogMessage
    {
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private Exception exception;

        public Exception Exception
        {
            get { return exception; }
            set { exception = value; }
        }

        public DateTime Date { get; }
        public LogMessage()
        {
            Date = DateTime.Now;
        }
        public override string ToString()
        {
            return "Error:" + exception.Message + " StackTrace:" + exception.StackTrace +
                   " Date:" + Date + " Info: " + Message;
        }
    }

    public interface ILogger
    {
        void Info(LogMessage message);
        void Error(LogMessage message);
        void Warning(LogMessage message);
        void Fatal(LogMessage message);
        void Trace(LogMessage message);
        LoggerType Type { get; }
    }

    public static class LoggerManager
    {
        private static readonly Dictionary<LoggerType, ILogger> Loggers;

        static LoggerManager()
        {
            Loggers = new Dictionary<LoggerType, ILogger>();
            Loggers.Add(LoggerType.TextFile, new TextFileLogger());
            Loggers.Add(LoggerType.Console, new ConsoleLogger());
        }

        public static ILogger Get(LoggerType type)
        {
            if (Loggers.ContainsKey((type)))
            {
                return Loggers[type];
            }
            throw new ArgumentException("Incorrect value " + type + " param: tipe");
        }
    }

    public static class NullValidator
    {
        public static void Check(object param, string name)
        {
            if (param == null)
            {
                throw new ArgumentException("Paramaeter " + name + " is null");
            }
        }
    }

    public class TextFileLogger : ILogger
    {
        public LoggerType Type
        {
            get { return LoggerType.TextFile; }
        }
        public void Info(LogMessage message)
        {
            NullValidator.Check(message, "m");
        }

        public void Error(LogMessage message)
        {
            NullValidator.Check(message, "m");
        }

        public void Warning(LogMessage message)
        {
            NullValidator.Check(message, "m");
        }

        public void Fatal(LogMessage message)
        {
            NullValidator.Check(message, "m");
        }

        public void Trace(LogMessage message)
        {
            NullValidator.Check(message, "m");
        }
    }

    public class ConsoleLogger : ILogger
    {
        public LoggerType Type
        {
            get { return LoggerType.Console; }
        }

        public void Info(LogMessage message)
        {
            NullValidator.Check(message,"m");
            Console.WriteLine("INFO " + message.Message);
        }

        public void Error(LogMessage message)
        {
            NullValidator.Check(message, "m");
            Console.WriteLine("ERROR " + message);
        }

        public void Warning(LogMessage message)
        {
            NullValidator.Check(message, "m");
            Console.WriteLine("WARNING " + message.Message);
        }

        public void Fatal(LogMessage message)
        {
            NullValidator.Check(message, "m");
            Console.WriteLine("FATAL " + message);
        }

        public void Trace(LogMessage message)
        {
            NullValidator.Check(message, "m");
            Console.WriteLine("TRACE " + message.Message);
        }
    }
}
