using System;
using System.ServiceModel;
using CarRentalService;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(RentalReservations)))
            {
                host.Open();
                Console.WriteLine("Press ENTER to end service");
                Console.ReadLine();
                host.Close();
            }
        }

    }
}
