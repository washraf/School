using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Routing;
using System.Text;
using System.Threading.Tasks;

namespace School.Management.Services.TheRouting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(RoutingService));
            host.Open();
            Console.WriteLine("Press any Key to Close");
            Console.ReadLine();
            host.Close();
        }
    }
}
