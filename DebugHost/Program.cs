using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V37ZEN.DatagramService;

namespace DebugHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Datagram()
            {
                Message = "Hali!",
                Timestamp = DateTime.UtcNow,
                Metadata = { { "a", "b" }, { "LEVEL", "Debug" } }
            };

            Console.WriteLine(d.ToString());
            Console.ReadKey();
        }
    }
}
