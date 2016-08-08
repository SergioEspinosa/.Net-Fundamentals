using System;
using System.Collections.Generic;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LoggerManager.Get(LoggerType.Console);

            try
            {
                var processor = new OrderProcessor();

                var products = new List<Product>
                {
                    new Product {Name = "Sugar", Quantity = 10},
                    new Product {Name = "Chocolate", Quantity = 10}
                };
                var order = new Order(new Person("Alex"), null, new Address("KK"), products);
                processor.Execute(order);
                logger.Trace(new LogMessage { Message = "Order processed" });
            }
            catch (Exception ex)
            {
                if (logger == null)
                {
                    return;
                }
                if (ex.Message.Contains("null"))
                {
                    Console.WriteLine("Fix the null order");
                    logger.Error(new LogMessage { Exception = ex, Message = "error" });
                }
                else if (ex.Message == "Order not processed")
                {
                    Console.WriteLine("Check the parameter order");
                    logger.Warning(new LogMessage { Exception = ex, Message = "error" });
                }
                else
                {
                    Console.WriteLine("Only god knows what happened :S");
                    logger.Fatal(new LogMessage { Exception = ex, Message = "error" });
                }
            }
            Console.ReadLine();
        }
    }
}
