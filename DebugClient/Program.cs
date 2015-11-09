using DebugClient.EchoDatagramClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;

namespace DebugClient
{
    class Program
    {

        static EndpointAddress Address { get; set; }

        public static EndpointAddress DiscoverAddress()
        {
            Console.WriteLine("Discovery stated at " + DateTime.Now);

            // Create DiscoveryClient
            DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());

            // Find ICalculatorService endpoints            
            FindResponse findResponse = discoveryClient.Find(new FindCriteria(typeof(IDatagramService)));

            Console.WriteLine("Discovery finished at " + DateTime.Now);

            if (findResponse.Endpoints.Count> 0)
            {
                foreach (var e in findResponse.Endpoints)
                {
                    Console.WriteLine(e.Address + ", ContractTypeNames:" + e.ContractTypeNames
                        + ", Scopes:" + e.Scopes + ", ListenUris:" + e.ListenUris);
                }


                return findResponse.Endpoints[0].Address;

            }
            else
            {
                Console.WriteLine("No service found.");
                return null;
            }
        }

        static void Main(string[] args)
        {
            #region dyscovery_test1
            while (true)
            {
                try
                {                    
                    if(Address == null)
                    {
                        Address = DiscoverAddress();
                    }
                    if(Address != null) { 

                        Binding b = new BasicHttpBinding();

                        if ("https".Equals(Address.Uri.Scheme))
                        {
                            var wsb = new WSHttpBinding();
                            wsb.Security.Mode = SecurityMode.Transport;
                            b = wsb;
                        }

                        var factory = new ChannelFactory<IDatagramService>(b, Address);
                        var channel = factory.CreateChannel();

                        channel.ProcessDatagram(
                            new Datagram
                            {
                                Message = "Hello!",
                                Timestamp = DateTime.UtcNow
                            }
                        );
                    }
                    else
                    {
                        Console.WriteLine("No Endpoint.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Address = null;
                    continue;
                }

                Console.WriteLine("Press q to exit.");
                char c = Console.ReadKey().KeyChar;

                if ('q' == c || 'Q' == c)
                {
                    System.Environment.Exit(0);
                }
            }


            #endregion


            #region terminaton_protection
            //Console.ReadKey();
            #endregion

        }


       
    }
}
