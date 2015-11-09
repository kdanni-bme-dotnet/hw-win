using DebugClient.EchoDatagramClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;

namespace DebugClient
{
    class Program
    {
        static void Main(string[] args)
        {
            #region dyscovery_test1
            // Create DiscoveryClient
            DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());

            // Find ICalculatorService endpoints            
            FindResponse findResponse = discoveryClient.Find(new FindCriteria(typeof(IDatagramService)));

            if (findResponse.Endpoints.Count > 0)
            {
                foreach (var e in findResponse.Endpoints) {
                    Console.WriteLine(e.Address + ", ContractTypeNames:" + e.ContractTypeNames 
                        + ", Scopes:" + e.Scopes + ", ListenUris:" + e.ListenUris);
                }
            }
            else
            {
                Console.WriteLine("No service found.");
            }




            #endregion


            #region terminaton_protection
            Console.ReadKey();
            #endregion

        }
    }
}
