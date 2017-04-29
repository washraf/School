using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utils.Trace;
using School.Management.Application.Contracts;
using School.Management.Application.Implementation;
using School.Management.Domain.Contracts;
using School.Management.Domain.Entities;
using School.Management.Infrastructure.DataAccess.Context;
using School.Management.Infrastructure.DataAccess.Repositories;
using School.Management.Presentation.Console.CustomerService;
using School.Management.Presentation.Console.StudentAffairsService;
using School.Management.Services.DiscoverableService;

namespace School.Management.Presentation.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //TcpDemo();
            //HttpDemo();
            //HttpsDemo();
            //DiscoverableDemo();
            RoutedServiceDemo();
        }

        private static void RoutedServiceDemo()
        {
            CustomerService.CustomerServiceClient client
                = new CustomerServiceClient("CustomerRouter");
            var normal = client.AnswerQuestion("ali", "What is my name");
            var premum = client.AnswerQuestion("walid", "What is my name");

            System.Console.WriteLine(normal);
            System.Console.WriteLine(premum);

            for (int i = 20; i >= 0; i--)
            {
                System.Console.WriteLine(client.AnswerQuestion("User", ""));

            }

        }
        private static void DiscoverableDemo()
        {
            DiscoveryClient clientProxy =
                new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindResponse response =
                clientProxy.Find(new FindCriteria(typeof(IAutoDiscover))
                {
                    MaxResults = 1,
                    Duration = new TimeSpan(0, 0, 0, 5)
                });
            if (response.Endpoints.Count != 0)
            {
                WSHttpBinding wsHttp = new WSHttpBinding();
                ChannelFactory<IAutoDiscover> autoDisvoverChannelFactory =
                    new ChannelFactory<IAutoDiscover>(wsHttp, response.Endpoints[0].Address);
                var proxy = autoDisvoverChannelFactory.CreateChannel();
                System.Console.WriteLine(proxy.GetMyName());
            }
            else
            {
                System.Console.WriteLine("Nothing Was Found");
            }
        }

        private static void TcpDemo()
        {
            StudentAffairsServiceClient client =
                new StudentAffairsServiceClient("tcpEndPoint");
            //client.ClientCredentials.Windows.ClientCredential.UserName = @"Start\Walid";
            //client.ClientCredentials.Windows.ClientCredential.Password = "I won't show my password";
            
            client.Open();

            client.CreateStudent(new Student()
            {
                Age = 15,
                Email = "waid@walid.com",
                Name = "wwwwwwwwwwwwwwwwwwwwwwwwww"
            });
            client.Close();
        }
        private static void HttpDemo()
        {
            StudentAffairsServiceClient client =
               new StudentAffairsServiceClient("WSHttpBinding_IStudentAffairsService");
            //client.ClientCredentials.Windows.ClientCredential.UserName = @"Start\Walid";
            //client.ClientCredentials.Windows.ClientCredential.Password = "I won't show my password";

            client.ClientCredentials.UserName.UserName = "walid";
            client.ClientCredentials.UserName.Password = "walid";

            client.Open();

            client.CreateStudent(new Student()
            {
                Age = 15,
                Email = "waid@walid.com",
                Name = "wwwwwwwwwwwwwwwwwwwwwwwwww"
            });
            client.Close();
        }
        private static void HttpsDemo()
        {
            httpsService.StudentAffairsServiceClient client = new httpsService.StudentAffairsServiceClient();
            client.ClientCredentials.UserName.UserName = "walid";
            client.ClientCredentials.UserName.Password = "walid";

            client.Open();

            client.CreateStudent(new Student()
            {
                Age = 15,
                Email = "waid@walid.com",
                Name = "wwwwwwwwwwwwwwwwwwwwwwwwww"
            });
            client.Close();
        }
    }
}
