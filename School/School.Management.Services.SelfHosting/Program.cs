using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using School.Management.Services.Implementation;

namespace School.Management.Services.SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(StudentAffairsService));
            //Type contract = typeof(ICourseManagementServices);
            //Binding binding = new NetTcpBinding();
            //string address = "net.tcp://www.localhost:9746/CourseService";
            //host.AddServiceEndpoint(contract, binding, address);
            host.Open();
            Console.WriteLine("Press Enter to Exit ...");
            Console.ReadLine();
            host.Close();
        }
    }
}
