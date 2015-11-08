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
            #endregion




            Console.WriteLine(d2.ToString());
            Console.ReadKey();
        }
    }
}
