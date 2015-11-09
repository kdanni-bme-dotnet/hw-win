using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V37ZEN.DatagramService;
using V37ZEN.DatagramService.Host;

namespace DebugHost
{
    class Program
    {
        static void Main(string[] args)
        {
            #region datagram_toString_test
            var d = new Datagram
            {
                Message = "Hali!",
                Timestamp = DateTime.UtcNow,
                Metadata = new Dictionary<string,string>
                {
                    { "a", "b" },
                    { "LEVEL", "Debug" }
                }
            };

            Console.WriteLine(d.ToString());

            var d2 = new Datagram
            {
                Message = "Hali!",
                Timestamp = DateTime.UtcNow
            };
            Console.WriteLine();
            Console.WriteLine(d2.ToString());
            #endregion

            using (var host = new DatagramServiceMexHost(new Uri("http://localhost:8085/datagram")))
            {
                host.Open();
                Console.WriteLine("Datagram Service is ready.");
                Console.WriteLine(host.Address);

                Console.ReadLine();


                host.ChangeAddress(new Uri("http://localhost:8085/test"));
                Console.WriteLine("Datagram Service is rehosted.");
                Console.WriteLine(host.Address);

                Console.ReadLine();
            }

            Console.WriteLine("Datagram Service closed.");




            #region termination_protection
            Console.ReadKey();
            #endregion
        }
    }
}
