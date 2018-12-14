using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace WCFHostREST
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WCFService.RentCarService)))
            {
                // Start the ServiceHost.
                host.Open();
                Console.WriteLine("Host REST started @" + DateTime.Now);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();

            }
        }
    }
}
