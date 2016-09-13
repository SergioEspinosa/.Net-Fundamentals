using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHttp = new HttpCarRentalService.ReservationsClient();
            serviceHttp.ClientCredentials.UserName.UserName = "alex";
            serviceHttp.ClientCredentials.UserName.Password = "123456";
            var checkHttp = serviceHttp.Check(null);

            var serviceTcp = new TcpCarRenatlService.ReservationsClient();
            var checkTcp = serviceTcp.Check(null);

            Console.WriteLine($"Check HTTP: {checkHttp}");
            Console.WriteLine($"Check TPC: {checkHttp}");

            Console.ReadLine();
        }
    }
}
